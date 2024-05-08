using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.DefaultViewComponents
{
    public class _DefaultFeatureProductsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
