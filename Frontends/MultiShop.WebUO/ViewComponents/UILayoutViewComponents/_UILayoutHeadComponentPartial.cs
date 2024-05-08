using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
