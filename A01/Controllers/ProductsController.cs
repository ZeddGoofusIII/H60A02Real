
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A01.models;
using A01.Models;
using A01.Services;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

[Authorize(Roles = "Manager, Clerk")]
public class ProductsController : Controller
{
  
    private readonly HttpClient _httpClient;
    public ProductsController( HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // GET: PRODUCTS
    public IActionResult Index()    
    {
        string endpoint = "http://localhost:44387/api/Products";

        var response = _httpClient.GetAsync(endpoint).Result;
        List<Product> products = JsonSerializer.Deserialize<List<Product>>(response.Content.ReadAsStringAsync().Result);

        return View(products);
    }

    // GET: PRODUCTS/Details/5
    [Route("Products/Details/{productid}")]
    public IActionResult Details(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        string endpoint = $"http://localhost:44387/api/Products/{productid.Value}";

        var response = _httpClient.GetAsync(endpoint).Result;

        Product product = JsonSerializer.Deserialize<Product>(response.Content.ReadAsStringAsync().Result);

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
        string endpoint = "http://localhost:44387/api/Products";

        var response = await _httpClient.PostAsJsonAsync(endpoint, product);

        if (response.IsSuccessStatusCode)
        {
            return RedirectToAction(nameof(Index));
        }
        else
        {
            ModelState.AddModelError(string.Empty, "An error occurred while creating the product.");
            return View(product);
        }
    }

    

    // GET: PRODUCTS/Delete/5
    [Route("Products/Delete/{productid}")]
    public IActionResult Delete(int? productid)
    {
        if (productid == null)
        {
            return NotFound();
        }

        string endpoint = $"http://localhost:44387/api/Products/{productid.Value}";

        var response = _httpClient.GetAsync(endpoint).Result;

        Product product = JsonSerializer.Deserialize<Product>(response.Content.ReadAsStringAsync().Result);

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
        string endpoint = $"http://localhost:44387/api/Products/{productid.Value}";

        var response = _httpClient.DeleteAsync(endpoint).Result;

        if(!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while deleting the product.");
            return View();
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
    public async Task<IActionResult> UpdateStock(StockHelper helper, int productid)
    {
        string endpoint = $"http://localhost:44387/api/Products/Stockchange/{productid}?stockChange={helper.StockChange}";

        var response = await _httpClient.PutAsJsonAsync(endpoint, helper);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "An error occurred while updating the stock.");
            return View(helper);
        }
        return RedirectToAction(nameof(Index));
    }


    [Route("Products/EditPrice/{productid}")]
    [Authorize(Roles = "Manager")]
    public IActionResult EditPrice(int productid)
    {
        string endpoint = $"http://localhost:44387/api/Products/{productid}";

        var response = _httpClient.GetAsync(endpoint).Result;

        Product prod = JsonSerializer.Deserialize<Product>(response.Content.ReadAsStringAsync().Result);

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
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> EditPrice(PriceHelper helper, int productid)
    {
        helper.ProdId = productid;
        try
        {
            string endpoint = $"http://localhost:44387/api/Products/Pricechange/{helper.ProdId}";

            var response = await _httpClient.PutAsJsonAsync(endpoint, helper);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the price.");
                return View(helper);
            }

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
        return true;
    }


}
