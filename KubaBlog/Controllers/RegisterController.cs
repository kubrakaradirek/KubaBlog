using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.BusinessLayer.ValidationRules;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace KubaBlog.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        WriterManager vm=new WriterManager(new EfWriterRepository());
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
		public IActionResult Index(Writer p)
		{
            WriterValidator wv=new WriterValidator();
			FluentValidation.Results.ValidationResult results = wv.Validate(p);
            if(results.IsValid)
            {
				p.WriterStatus = true;
				p.WriterAbout = "Deneme Test";
				vm.TAdd(p);
				return RedirectToAction("Index", "Blog");
			}
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View();
            }
			
		}

	}
}
