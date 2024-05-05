using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            Context c=new Context();
            var userName = User.Identity.Name;
            var userEmail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            var writerId=c.Writers.Where(x=>x.WriterMail==userEmail).Select(y=>y.WriterId).FirstOrDefault();
            ViewBag.v1=c.Blogs.Count().ToString();
            ViewBag.v2 = c.Blogs.Where(x => x.WriterId == writerId).Count();
            ViewBag.v3 = c.Categories.Count();
            return View();
        }
    }
}
