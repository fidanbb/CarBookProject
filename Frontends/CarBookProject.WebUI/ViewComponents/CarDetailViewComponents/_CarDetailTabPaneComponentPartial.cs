﻿using Microsoft.AspNetCore.Mvc;

namespace CarBookProject.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailTabPaneComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
