using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm=new WriterManager(new EfWriterRepository());
        Context c=new Context();

		public IViewComponentResult Invoke()
        {
            var userName = User.Identity.Name;
            ViewBag.veri = userName;
            var userEmail=c.Users.Where(x=>x.UserName==userName).Select(y=>y.Email).FirstOrDefault();
            var writerId=c.Writers.Where(x=>x.WriterMail==userEmail).Select(y=>y.WriterId).FirstOrDefault();
            var values = vm.GetWriterById(writerId);
            return View(values);
        }
    }
}
