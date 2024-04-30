using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Comments
{
    public class CommentListByBlog : ViewComponent
    {
        CommentManager cm=new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList(5);
            return View(values);
        }
    }
}
