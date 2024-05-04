using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.BusinessLayer.ValidationRules;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;

namespace KubaBlog.Controllers
{
    public class BlogController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepositoy());
        Context c = new Context();
        public IActionResult Index()
        {
            var values = bm.GetBlogLisWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {
            ViewBag.i = id;
            var values=bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()
        {
            var userEmail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            var values=bm.GetListWithCategoryByWriterBm(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult BlogAdd()
        {
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View();
        }

        [HttpPost]
        public IActionResult BlogAdd(Blog p)
        {
            var userEmail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            BlogValidator wv = new BlogValidator();
            FluentValidation.Results.ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreatedDate = DateTime.Now.ToShortDateString();
                p.WriterId = writerId;
                bm.TAdd(p); 
                return RedirectToAction("BlogListByWriter", "Blog");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [AllowAnonymous]
        public IActionResult BlogDelete(int id)
        {
            var value = bm.TGetById(id);
            bm.TDelete(value);
            return RedirectToAction("BlogListByWriter");
        }
        [HttpGet]
        public IActionResult EditBlog(int id)
        {
            var value = bm.TGetById(id);
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,
                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.cv = categoryValues;
            return View(value);
        }

        [HttpPost]
        public IActionResult EditBlog(Blog p)
        {
            var userEmail = User.Identity.Name;
            var writerId = c.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterId).FirstOrDefault();
            var blogValue = bm.TGetById(p.BlogId);
            p.WriterId = writerId;
            p.BlogCreatedDate = DateTime.Now.ToShortDateString();
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
        }
    }
}
