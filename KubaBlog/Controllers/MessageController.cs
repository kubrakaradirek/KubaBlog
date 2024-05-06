using DocumentFormat.OpenXml.Bibliography;
using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace KubaBlog.Controllers
{
    public class MessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Reposiyory());
       
        public IActionResult InBox()
        {
            var writerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        
        public IActionResult MessageDetails(int id)
        {
            var value = mm.TGetById(id);
            return View(value);
        }

        public IActionResult SendBox()
        {
            var writerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetSendboxListByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message2 p)
        {
            var writerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            p.SenderId=writerId;
            p.ReceiverId = 2;
            p.MessageStatus = true;
            p.MessageDate=Convert.ToDateTime(DateTime.Now.ToShortDateString());
            mm.TAdd(p);
            return RedirectToAction("InBox");
        }
    }
}
