using Microsoft.AspNetCore.Mvc;

namespace A01.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
