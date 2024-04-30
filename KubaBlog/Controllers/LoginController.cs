using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
	public class LoginController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
