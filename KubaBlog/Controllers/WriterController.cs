using FluentValidation.Results;
using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.BusinessLayer.ValidationRules;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using KubaBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KubaBlog.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());
        [Authorize]
		public IActionResult Index()
		{
            var userEmail = User.Identity.Name;
            ViewBag.v = userEmail;
            Context c=new Context();
            var writerName = c.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2=writerName;
			return View();
		}
		public IActionResult WriterProfile()
		{
			return View();
		}
		[AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
		{
			return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]
        public IActionResult WriterEditProfile()
        {
            Context c=new Context();    
            var userEmail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            var writerValues = wm.TGetById(writerId);
            return View(writerValues);
        }
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)
        {
            var pas1 = Request.Form["pass1"];
            var pas2 = Request.Form["pass2"];
            if (pas1 == pas2)
            {
                p.WriterPassword = pas2;
                WriterValidator validationRules = new WriterValidator();
                ValidationResult result = validationRules.Validate(p);
                if (result.IsValid)
                {
                    wm.TUpdate(p);
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                ViewBag.hata = "Girdiğiniz Parolalar Uyuşmuyor!";
            }
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterAdd()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterAdd(AddProfileImage p)
        {
            Writer w=new Writer();
            if(p.WriterImage!=null)
            {
                var extension=Path.GetExtension(p.WriterImage.FileName);
                var newImageName=Guid.NewGuid()+extension;
                var location=Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",newImageName);
                var stream=new FileStream(location,FileMode.Create);
                p.WriterImage.CopyTo(stream);
                w.WriterImage = newImageName;
            }
            w.WriterMail=p.WriterMail;
            w.WriterName=p.WriterName;
            w.WriterStatus = true;
            w.WriterPassword = p.WriterPassword;
            w.WriterAbout= p.WriterAbout;
            wm.TAdd(w);
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
