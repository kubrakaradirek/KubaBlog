﻿using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Indexx()
        {
            return View();
        }
    }
}