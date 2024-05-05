using FluentValidation.Results;
using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.BusinessLayer.ValidationRules;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using KubaBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace KubaBlog.Controllers
{
	public class WriterController : Controller
	{
		WriterManager wm=new WriterManager(new EfWriterRepository());
        private readonly UserManager<AppUser> _userManager;
        UserManager userManager = new UserManager(new EfUserRepository());


        public WriterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

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
        public async Task<IActionResult> WriterEditProfile()
        {
            var values=await _userManager.FindByNameAsync(User.Identity.Name);
            UserUpdateVİewModel model=new UserUpdateVİewModel();
           model.namesurname = values.NameSurname;
            model.imageurl = values.ImageUrl;
            model.email = values.Email;
            model.username = values.UserName;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> WriterEditProfile(UserUpdateVİewModel model)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            values.NameSurname = model.namesurname;
            values.ImageUrl = model.imageurl;
            values.Email = model.email;
            var result=await _userManager.UpdateAsync(values);
            return RedirectToAction("Index", "Dashboard");
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
