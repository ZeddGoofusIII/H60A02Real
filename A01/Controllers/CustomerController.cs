using Microsoft.AspNetCore.Mvc;
using A01.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;

namespace A01.Controllers
{
    [Route("Customer")]
    [Authorize(Roles = "Manager, Clerk")]
    public class CustomerController : Controller
    {

        private readonly HttpClient _httpClient;

        public CustomerController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public IActionResult Index()
        {
            var endpoint = "https://localhost:44387/api/Customer";
            var response = _httpClient.GetAsync(endpoint).Result;  
            List<Customer> customers = JsonSerializer.Deserialize<List<Customer>>(response.Content.ReadAsStringAsync().Result);
            return View(customers);
        }

        [Route("Details/{customerid}")]
        [HttpGet]
        public IActionResult Details(int? customerid)
        {
            var endpoint = $"https://localhost:44387/api/Customer/{customerid.Value}";
            var response = _httpClient.GetAsync(endpoint).Result;
            Customer customer = JsonSerializer.Deserialize<Customer>(response.Content.ReadAsStringAsync().Result);
            return View(customer);
        }
    }
}
