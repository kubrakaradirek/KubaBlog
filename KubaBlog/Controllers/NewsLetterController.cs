using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KubaBlog.Controllers
{
    public class NewsLetterController : Controller
    {
        NewsLetterManager nm = new NewsLetterManager(new EfNewsLetterRepository());

        [HttpGet]
        public IActionResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SubscribeEmail(NewsLetter newsLetter)
        {
            newsLetter.EmailStatus = true;
            nm.AddNewsLetter(newsLetter);
            Response.Redirect("/Blog/Index/" + 1);
            return PartialView();

        }

    }
}
