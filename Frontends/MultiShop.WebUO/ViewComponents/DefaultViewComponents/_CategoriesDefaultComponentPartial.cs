﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUO.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
