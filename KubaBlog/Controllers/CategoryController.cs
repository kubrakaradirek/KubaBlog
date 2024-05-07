using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Writer")]
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
