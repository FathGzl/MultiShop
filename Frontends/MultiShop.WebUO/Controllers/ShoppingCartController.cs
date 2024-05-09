using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebIU.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
