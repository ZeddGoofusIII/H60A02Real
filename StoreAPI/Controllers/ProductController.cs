using Microsoft.AspNetCore.Mvc;
using StoreAPI.Model;

namespace StoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IStoreRepo storeRepo;

        public ProductController(IStoreRepo storeRepo)
        {
            this.storeRepo = storeRepo;
        }
        public IActionResult GetProducts()
        {
            var products = storeRepo.GetProducts();
            return Ok(products);
        }
    }
}
