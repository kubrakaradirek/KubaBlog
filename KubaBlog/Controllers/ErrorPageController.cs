using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error1(int code)
        {
            return View();
        }
    }
}
