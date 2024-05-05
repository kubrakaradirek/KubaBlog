using KubaBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CategoryChart()
        {
            List<CategoryClass> list = new List<CategoryClass>();
            list.Add(new CategoryClass
            {
                categoryName = "Teknoloji",
                categoryCount = 10
            });
            list.Add(new CategoryClass
            {
                categoryName = "Yazılım",
                categoryCount = 14
            });
            list.Add(new CategoryClass
            {
                categoryName = "Spor",
                categoryCount = 5
            });
            list.Add(new CategoryClass
            {
                categoryName = "Sinema",
                categoryCount = 2
            });

            return Json(new { jsonlist = list });
        }
    }
}

