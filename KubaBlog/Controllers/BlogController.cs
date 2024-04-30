using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
