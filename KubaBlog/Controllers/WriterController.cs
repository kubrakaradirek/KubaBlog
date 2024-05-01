using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
	public class WriterController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
	}
}
