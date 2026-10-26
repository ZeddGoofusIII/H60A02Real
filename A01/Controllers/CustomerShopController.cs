using Microsoft.AspNetCore.Mvc;
using A01.models;
using System.Text.Json;

namespace A01.Controllers
{
    public class CustomerShopController : Controller
    {
      private readonly HttpClient _httpClient;
        public CustomerShopController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        [Route("CustomerShop/Details/{customerid}")]
        [HttpGet]
        public IActionResult Details(int? customerid)
        {
            var endpoint = $"http://localhost:44387/api/products/{customerid.Value}";
            var response = _httpClient.GetAsync(endpoint).Result;
            Product product = JsonSerializer.Deserialize<Product>(response.Content.ReadAsStringAsync().Result);
            return View(product);
        }

        [Route("CustomerShop")]
        public IActionResult Index()
        {
            var endpoint = "http://localhost:44387/api/Products";
            var response = _httpClient.GetAsync(endpoint).Result;
            List<Product> products = JsonSerializer.Deserialize<List<Product>>(response.Content.ReadAsStringAsync().Result);
            return View(products);
        }
    }
}
