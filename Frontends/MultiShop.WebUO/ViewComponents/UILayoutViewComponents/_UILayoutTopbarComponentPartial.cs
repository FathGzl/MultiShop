using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutTopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
