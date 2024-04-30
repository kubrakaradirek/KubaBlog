using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository()); 
        public IActionResult Index()
        {
            var values = bm.GetBlogLisWithCategory();
            return View(values);
        }
    }
}
