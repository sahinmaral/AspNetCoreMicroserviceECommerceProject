﻿using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents
{
    public class ProductDetailReviewViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
