using KubaBlog.BusinessLayer.Concrete;
using KubaBlog.DataAccessLayer.Concrete;
using KubaBlog.EntityLayer.Concrete;
using KubaBlog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KubaBlog.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
	{
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserSignInViewModel model)
		{
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.userName, model.password, false, true);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.userName); // Kullanıcıyı bul
                    if (user != null)
                    {
                        if (await _userManager.IsInRoleAsync(user, "Admin")) // Kullanıcı admin rolünde mi?
                        {
                            return RedirectToAction("Index", "Widget", new { area = "Admin" });
                        }
                        else if (await _userManager.IsInRoleAsync(user, "Writer")) // Kullanıcı writer rolünde mi?
                        {
                            return RedirectToAction("Index", "Dashboard");
                        }
                    }
                    else
                    {
                        // Kullanıcı bulunamadıysa veya rolleri atanmamışsa hata sayfasına yönlendir
                        return RedirectToAction("Error1", "ErrorPage");
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Kullanıcı adınız veya parolanız hatalı lütfen tekrar deneyiniz.";
                    return View(model);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
		public IActionResult AccessDenied()
		{
			return View();
		}
    }
}