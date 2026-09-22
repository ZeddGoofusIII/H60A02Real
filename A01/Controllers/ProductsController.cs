
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A01.models;
using A01.Models;
using A01.Services;

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
    [Route("Products/Details/{productid}")]
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
        var cat = _repo.GetCategoryById(product.ProductCategoryId);
        product.ProdCat = cat;
        if (ModelState.IsValid)
        {

            _repo.InsertProduct(product);

            return RedirectToAction(nameof(Index));
        }
        return View(product);
    }

    

    // GET: PRODUCTS/Delete/5
    [Route("Products/Delete/{productid}")]
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

    [Route("Products/UpdateStock/{productid}")]
    public IActionResult UpdateStock(int productid)
    {
 
        var helper = new StockHelper() { Prodid = productid, StockChange = 0};
        return View(helper);
    }

    [HttpPost]
    [Route("Products/UpdateStock/{productid}")]
    public IActionResult UpdateStock(StockHelper helper)
    {
        try
        {
            _repo.UpdateStock(helper.Prodid, helper.StockChange);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("StockChange", ex.Message);
            return View(helper);
        }
        
        
    }


    [Route("Products/EditPrice/{productid}")]
    public IActionResult EditPrice(int productid)
    {
        var prod = _repo.GetProductById(productid);
        var helper = new PriceHelper()
        {
            ProdId = productid,
            BuyPrice = prod.BuyPrice,
            SellPrice = prod.SellPrice
        };
        return View(helper);
    }

    [HttpPost]
    [Route("Products/EditPrice/{productid}")]
    public IActionResult EditPrice(PriceHelper helper)
    {
        try
        {
            _repo.UpdatePrice(helper);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("SellPrice", ex.Message);
            return View(helper);
        }
        }

    private bool ProductExists(int? productid)
    {
        return _context.Products.Any(e => e.ProductId == productid);
    }


}
