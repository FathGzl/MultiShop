using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
