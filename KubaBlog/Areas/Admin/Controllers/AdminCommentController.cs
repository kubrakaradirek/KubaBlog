using DocumentFormat.OpenXml.Office2021.PowerPoint.Comment;
using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace KubaBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminCommentController : Controller
    {
        CommentManager commentManager=new CommentManager(new EfCommentRepository());
        [HttpGet]
        public IActionResult Index(int page = 1)
        {
            var values = commentManager.GetCommentWithBlog().ToPagedList(page, 20);
            return View(values);
        }
      
    }
}
