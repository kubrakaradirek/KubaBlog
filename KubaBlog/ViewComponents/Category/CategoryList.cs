using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Category
{
    public class CategoryList:ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepositoy());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
