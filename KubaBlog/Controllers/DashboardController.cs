using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KubaBlog.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Writer")]
    public class DashboardController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        public IActionResult Index()
        {
            Context c = new Context();
            var writerId =int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            List<Blog> blogList = bm.GetBlogListByWriter(writerId);
            int totalBlogs = blogList.Count;
            ViewBag.v1 = c.Blogs.Count().ToString();
            ViewBag.v3 = c.Categories.Count();
            ViewBag.v2=totalBlogs;
            return View();

            //Context c=new Context();
            //var userName = User.Identity.Name;
            //var userEmail = c.Users.Where(x => x.UserName == userName).Select(y => y.Email).FirstOrDefault();
            //var writerId=c.Writers.Where(x=>x.WriterMail==userEmail).Select(y=>y.WriterId).FirstOrDefault();
            //ViewBag.v1=c.Blogs.Count().ToString();
            //ViewBag.v2 = c.Blogs.Where(x => x.WriterId == writerId).Count();
            //ViewBag.v3 = c.Categories.Count();
            //return View();
        }
    }
}
