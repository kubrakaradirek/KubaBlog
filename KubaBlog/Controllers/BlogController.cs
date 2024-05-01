using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.BusinessLayer.ValidationRules;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Configuration;

namespace KubaBlog.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepositoy());
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
            var values=bm.GetListWithCategoryByWriterBm(2);
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
            BlogValidator wv = new BlogValidator();
            FluentValidation.Results.ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.BlogStatus = true;
                p.BlogCreatedDate = DateTime.Now.ToShortDateString();
                p.WriterId = 2;
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
            var blogValue = bm.TGetById(p.BlogId);
            p.WriterId = 2;
            p.BlogCreatedDate = DateTime.Now.ToShortDateString();
            p.BlogStatus = true;
            bm.TUpdate(p);
            return RedirectToAction("BlogListByWriter");
            //var username = User.Identity.Name;
            //var usermail = c.Users.Where(x => x.UserName == username).Select(y => y.Email).FirstOrDefault();
            //var writerID = c.Writers.Where(x => x.Mail == usermail).Select(y => y.WriterId).FirstOrDefault();

            ////var value = bm.GetBlogByID(blog.BlogId);
            //blog.WriterId = writerID;
            //blog.CreateDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            //blog.Status = true;
            //bm.TUpdate(blog);
            //GetCategoryList();
            //return RedirectToAction("GetBlogListByWriter");




        }
    }
}
