using KubaBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents
{
    public class CommentList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commetvalues = new List<UserComment> { new UserComment { Id = 1, Username = "Kübra" }, new UserComment { Id = 3, Username = "Merve" } };
            return View(commetvalues);
        }
    }
}
