using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.DataAccessLayer.EntityFramework;
using KubaBlog.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KubaBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminMessageController : Controller
    {
        Message2Manager mm = new Message2Manager(new EfMessage2Reposiyory());
        Context c = new Context();
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        public AdminMessageController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Inbox()
        {
            var writerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetInboxListByWriter(writerId);
            return View(values);
        }
        public IActionResult Sendbox()
        {
            var writerId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var values = mm.GetSendboxListByWriter(writerId);
            return View(values);
        }
        [HttpGet]
        public IActionResult ComposeMessage()
        {
            return View(Tuple.Create<Message2, AppUser>(new Message2(), new AppUser()));
        }
        [HttpPost]
        public async Task<IActionResult> ComposeMessage([Bind(Prefix = "Item1")] Message2 message, [Bind(Prefix = "Item2")] AppUser writer)
        {
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiver = await _userManager.FindByEmailAsync(writer.Email);
            message.SenderId = sender.Id;
            message.ReceiverId = receiver.Id;
            message.MessageDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.MessageStatus = true;
            mm.TAdd(message);
            return RedirectToAction("Sendbox");
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var inboxMessageCount = mm.GetInboxListByWriter(user.Id).Count();
            var sendMessageCount = mm.GetSendboxListByWriter(user.Id).Count();
            ViewBag.imc = inboxMessageCount;
            ViewBag.smc = sendMessageCount;

            var value = mm.TGetById(id);
            if (value.MessageStatus == false)
            {
                value.MessageStatus = true;
                mm.TUpdate(value);
            }

            return View(value);
        }
    }
}
