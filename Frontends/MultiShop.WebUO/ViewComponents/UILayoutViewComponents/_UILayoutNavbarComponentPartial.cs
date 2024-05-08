using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
