using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace KubaBlog.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic1 : ViewComponent
    {
        BlogManager bm=new BlogManager(new EfBlogRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = bm.GetList().Count();
            ViewBag.v2=c.Contacts.Count();
            ViewBag.v3=c.Comments.Count();

            //weatherapisi
            string api= "649bb58898c9e6600bf9f572f4294fb4";
            string connection = "https://api.openweathermap.org/data/2.5/weather?q=tekirdag&mode=xml&lang=tr&units=metric&appid="+api;
            XDocument document = XDocument.Load(connection);
            ViewBag.v4 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            return View();
        }
    }
}
