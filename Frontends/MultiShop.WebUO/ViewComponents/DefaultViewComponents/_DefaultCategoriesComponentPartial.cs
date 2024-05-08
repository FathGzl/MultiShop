using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoriesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
