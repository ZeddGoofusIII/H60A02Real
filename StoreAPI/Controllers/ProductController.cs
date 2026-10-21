using Microsoft.AspNetCore.Mvc;

namespace StoreAPI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
