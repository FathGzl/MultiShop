using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
