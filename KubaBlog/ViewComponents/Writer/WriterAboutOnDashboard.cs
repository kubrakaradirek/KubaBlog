using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm=new WriterManager(new EfWriterRepository());
        Context c=new Context();
        public IViewComponentResult Invoke()
        {
            var userEmail = User.Identity.Name;
            var writerId=c.Writers.Where(x=>x.WriterMail==userEmail).Select(y=>y.WriterId).FirstOrDefault();
            var values = vm.GetWriterById(writerId);
            return View(values);
        }
    }
}
