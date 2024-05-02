using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class NotificationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
