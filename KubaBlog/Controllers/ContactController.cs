using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
	{
		ContactManager cm=new ContactManager(new EfContactRepository());
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(Contact contact)
		{
			contact.ContactDate=DateTime.Parse(DateTime.Now.ToShortDateString());
			contact.ContactStatus = true;
			cm.ContactAdd(contact);
			return RedirectToAction("Index","Blog");
		}
	}
}
