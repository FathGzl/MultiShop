using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.DefaultViewComponents
{
    public class _DefaultSpeacialOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
