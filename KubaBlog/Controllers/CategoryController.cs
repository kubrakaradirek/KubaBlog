using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepositoy());
        public IActionResult Index()
        {
            var values=cm.GetList();
            return View(values);
        }
    }
}
