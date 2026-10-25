using Microsoft.AspNetCore.Mvc;

namespace A01.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
