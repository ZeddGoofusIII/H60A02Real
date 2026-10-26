
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A01.models;
using A01.Models;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
[Authorize(Roles = "Manager, Clerk")]
public class ProductCategoriesController : Controller
{
    private readonly HttpClient _httpClient;
    public ProductCategoriesController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET: PRODUCTCATEGORYS
    public IActionResult Index()    
    {
        var endpoint = "http://localhost:44387/api/ProductCategory";

        var response = _httpClient.GetAsync(endpoint).Result;

        List<ProductCategory> productcategories = JsonSerializer.Deserialize<List<ProductCategory>>(response.Content.ReadAsStringAsync().Result);
        return View(productcategories);
    }

    // GET: PRODUCTCATEGORYS/Details/5
    [Route("productCategories/Details/{productcategoryid}")]
    [HttpGet]
    public IActionResult Details(int? productcategoryid)
    {
       var endpoint = $"http://localhost:44387/api/ProductCategory/{productcategoryid.Value}";
        var response = _httpClient.GetAsync(endpoint).Result;
        ProductCategory productcategory = JsonSerializer.Deserialize<ProductCategory>(response.Content.ReadAsStringAsync().Result);
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
            var endpoint = "http://localhost:44387/api/ProductCategory";
            _httpClient.PostAsJsonAsync(endpoint, productcategory).Wait();
            return RedirectToAction(nameof(Index));
        }
        return View(productcategory);
    }
       

    // GET: PRODUCTCATEGORYS/Edit/5
    [Route("ProductCategories/Edit/{productcategoryid}")]
    public async Task<IActionResult> Edit(int? productcategoryid)
    {
        var endpoint = $"http://localhost:44387/api/ProductCategory/{productcategoryid.Value}";
        var response = _httpClient.GetAsync(endpoint).Result;
        ProductCategory productcategory = JsonSerializer.Deserialize<ProductCategory>(response.Content.ReadAsStringAsync().Result);
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
       var endpoint = $"http://localhost:44387/api/ProductCategory/{productcategoryid.Value}";
        _httpClient.PutAsJsonAsync(endpoint, productcategory).Wait();
        return RedirectToAction(nameof(Index));
    }

    // GET: PRODUCTCATEGORYS/Delete/5
    [Route("ProductCategories/Delete/{productid}")]
    public async Task<IActionResult> Delete(int? productcategoryid)
    {
       var endpoint = $"http://localhost:44387/api/ProductCategory/{productcategoryid.Value}";
        var response = _httpClient.GetAsync(endpoint).Result;
        ProductCategory productcategory = JsonSerializer.Deserialize<ProductCategory>(response.Content.ReadAsStringAsync().Result);
        return View(productcategory);
    }

    // POST: PRODUCTCATEGORYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? productcategoryid)
    {
       var endpoint = $"http://localhost:44387/api/ProductCategory/{productcategoryid.Value}";
        _httpClient.DeleteAsync(endpoint).Wait();
        return RedirectToAction(nameof(Index));
    }

    [Route("ProductCategories/ProductsInCategory/{Categoryid}")]
    public IActionResult ProductsInCategory(int Categoryid)
    {
        var endpoint = $"http://localhost:44387/api/ProductCategory/ProductsInCategory/{Categoryid}";
        var response = _httpClient.GetAsync(endpoint).Result;
        var products = JsonSerializer.Deserialize<List<Product>>(response.Content.ReadAsStringAsync().Result);
        return View(products);
    }


  
}
