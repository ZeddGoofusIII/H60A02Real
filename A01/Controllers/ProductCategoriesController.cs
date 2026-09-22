
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A01.models;
using A01.Models;

public class ProductCategoriesController : Controller
{
    private readonly IStoreRepo _repo;

    public ProductCategoriesController(IStoreRepo repo)
    {
        _repo = repo;
    }

    // GET: PRODUCTCATEGORYS
    public IActionResult Index()    
    {
        return View(_repo.GetCategories());
    }

    // GET: PRODUCTCATEGORYS/Details/5
    [Route("productCategories/Details/{productcategoryid}")]
    public IActionResult Details(int? productcategoryid)
    {
        if (productcategoryid == null)
        {
            return NotFound();
        }

        var productcategory = _repo.GetCategoryById(productcategoryid);
        if (productcategory == null)
        {
            return NotFound();
        }

        return View(productcategory);
    }

    // GET: PRODUCTCATEGORYS/Create
    [Route("ProductCategories/Create")]
    public IActionResult Create()
    {
        return View();
    }

    // POST: PRODUCTCATEGORYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("ProductCategories/Create")]
    public async Task<IActionResult> Create([Bind("ProductCategoryId,ProdCat,Products")] ProductCategory productcategory)
    {
        if (ModelState.IsValid)
        {
            _repo.addCategory(productcategory);
            return RedirectToAction(nameof(Index));
        }
        return View(productcategory);
    }

    // GET: PRODUCTCATEGORYS/Edit/5
    [Route("ProductCategories/Edit/{productcategoryid}")]
    public async Task<IActionResult> Edit(int? productcategoryid)
    {
        if (productcategoryid == null)
        {
            return NotFound();
        }

        var productcategory = _repo.GetCategoryById(productcategoryid);
        if (productcategory == null)
        {
            return NotFound();
        }
        return View(productcategory);
    }

    // POST: PRODUCTCATEGORYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("ProductCategories/Edit/{productcategoryid}")]
    public async Task<IActionResult> Edit(int? productcategoryid, [Bind("ProductCategoryId,ProdCat,Products")] ProductCategory productcategory)
    {
        if (productcategoryid != productcategory.ProductCategoryId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _repo.UpdateCategory(productcategory);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductCategoryExists(productcategory.ProductCategoryId))
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
        return View(productcategory);
    }

    // GET: PRODUCTCATEGORYS/Delete/5
    [Route("ProductCategories/Delete/{productid}")]
    public async Task<IActionResult> Delete(int? productcategoryid)
    {
        if (productcategoryid == null)
        {
            return NotFound();
        }

        var productcategory =  _repo.GetCategoryById(productcategoryid);
            
        if (productcategory == null)
        {
            return NotFound();
        }

        return View(productcategory);
    }

    // POST: PRODUCTCATEGORYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? productcategoryid)
    {
        var productcategory = _repo.GetCategoryById(productcategoryid);
        if (productcategory != null)
        {
            _repo.DeleteCategory(productcategory.ProductCategoryId);
        }

        return RedirectToAction(nameof(Index));
    }

    [Route("ProductCategories/ProductsInCategory/{Categoryid}")]
    public IActionResult ProductsInCategory(int Categoryid)
    {
        var list = _repo.ProductsByCategory(Categoryid);

        return View(list);
    }


    private bool ProductCategoryExists(int? productcategoryid)
    {
        return _repo.GetCategoryById(productcategoryid) != null;
    }
}
