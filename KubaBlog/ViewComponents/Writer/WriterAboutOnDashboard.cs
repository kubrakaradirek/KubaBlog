using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.ViewComponents.Writer
{
    public class WriterAboutOnDashboard:ViewComponent
    {
        WriterManager vm=new WriterManager(new EfWriterRepository());
        public IViewComponentResult Invoke()
        {
            var values = vm.GetWriterById(2);
            return View(values);
        }
    }
}
