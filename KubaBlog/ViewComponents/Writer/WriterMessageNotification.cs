using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KubaBlog.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        Message2Manager mm=new Message2Manager(new EfMessage2Reposiyory());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var writerId = int.Parse(ViewContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
    }
}
