using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        AboutManager abm=new AboutManager(new EfAboutRepository());
        public IActionResult Index()
        {
			var values = abm.GetList();
			return View(values);
        }
        public PartialViewResult SocialMediaAbout()
        {
            
            return PartialView();
        }
    }
}
