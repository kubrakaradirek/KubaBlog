using KubaBlog.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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
                categoryName = "Kişisel",
                categoryCount = 14
            });
            list.Add(new CategoryClass
            {
                categoryName = "Seyahat",
                categoryCount = 5
            });
            list.Add(new CategoryClass
            {
                categoryName = "Yaşam",
                categoryCount = 2
            }); list.Add(new CategoryClass
            {
                categoryName = "Moda",
                categoryCount = 4
            }); list.Add(new CategoryClass
            {
                categoryName = "Finans",
                categoryCount = 12
            }); list.Add(new CategoryClass
            {
                categoryName = "Aile",
                categoryCount = 3
            }); list.Add(new CategoryClass
            {
                categoryName = "Sanat",
                categoryCount = 7
            });

            return Json(new { jsonlist = list });
        }
    }
}

