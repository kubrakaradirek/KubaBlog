using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    [Authorize(Roles = "Admin,Moderator,Writer")]
    [AllowAnonymous]
    public class CommentController : Controller
    {
        CommentManager cm=new CommentManager(new EfCommentRepository());
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public  PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogId = 5;
            cm.CommentAdd(comment);
            Response.Redirect("/Blog/Index/" + 1);
            return PartialView();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            var values=cm.GetList(id);
            return PartialView(values);
        }
    }
}
