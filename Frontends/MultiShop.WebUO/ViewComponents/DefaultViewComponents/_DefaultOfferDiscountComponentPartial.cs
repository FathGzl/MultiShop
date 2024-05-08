using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.DefaultViewComponents
{
    public class _DefaultOfferDiscountComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
