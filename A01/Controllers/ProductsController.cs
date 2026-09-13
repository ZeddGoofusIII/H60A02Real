
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A01.models;
using A01.Models;

public class ProductsController : Controller
{
    private readonly H60AssignmentDbZlContext _context;
    private readonly IStoreRepo _repo;

    public ProductsController(H60AssignmentDbZlContext context, IStoreRepo repo)
    {
        _context = context;
        _repo = repo;
    }

    // GET: PRODUCTS
    public IActionResult Index()    
    {
        return View(_repo.GetProducts());
    }

    // GET: PRODUCTS/Details/5
    public IActionResult Details(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = _repo.GetProductById(productid.Value);

        return View(product);

    }

    // GET: PRODUCTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice,ProdCat")] Product product)
    {
        //var cat = _repo.GetCategoryById(product.ProdCatId);
        //product.ProdCat = cat;
        if (ModelState.IsValid)
        {

            _repo.InsertProduct(product);

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/Edit/5
    public IActionResult Edit(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = _repo.GetProductById(productid.Value);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    // POST: PRODUCTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? productid, [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice,ProdCat")] Product product)
    {
        if (productid != product.ProductId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repo.UpdateProduct(product);

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.ProductId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    // GET: PRODUCTS/Delete/5
    public IActionResult Delete(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        var product = _repo.GetProductById(productid.Value);
        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // POST: PRODUCTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? productid)
    {
        var product =  _repo.GetProductById(productid.Value);
        if (product != null)
        {
            _context.Products.Remove(product);
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult UpdateStock(int productid)
    {
        return View(_repo.GetProductById(productid));
    }

    private bool ProductExists(int? productid)
    {
        return _context.Products.Any(e => e.ProductId == productid);
    }


}
