using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels;
using Esram.Davetiye.Web.App.Manage.Sessions;
using Esram.Davetiye.Web.App.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Controllers
{
    [Area("ritapanel")]
    public class AccountController : Controller
    {
        [Route("ritapanel/login")]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [Route("ritapanel/login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var context = new EsramDbContext();
                var user = await context.Users.FirstOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("Kullanıcı bulunamadı", "Hatalı email adresi veya şifre");
                }
                else
                {
                    HttpContext.Response.Cookies.Append("_edul", user.Id.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
                    {
                        Expires = DateTime.Now.AddHours(3),
                        HttpOnly = true
                    });
                    return RedirectToAction("index", "dashboard");
                }
            }
            return View(model);
        }

        [Route("cikis")]
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("_edul");
            return RedirectToAction("login", "account");
        }

        [HttpPost]
        [Route("sifre-degis")]
        public IActionResult ChangePassword(string currentPassword,string password,string confirmPassword)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            var id = Convert.ToInt32(HttpContext.Request.Cookies["_edul"]);
            using var context = new EsramDbContext();
            var user = context.Users.Find(id);
            if (currentPassword==user.Password)
            {
                if (password==confirmPassword)
                {
                    user.Password = password;
                    context.Users.Update(user);
                    context.SaveChanges();
                    result.Add("status", true);
                    result.Add("message", "Şifreniz başarıyla değiştirildi");
                }
                else
                {
                    result.Add("status", false);
                    result.Add("message", "Yeni şifreler eşleşmiyor");
                }
            }
            else
            {
                result.Add("status", false);
                result.Add("message", "Mevcut şifre yanlış girildi");
            }
            return Json(result);
        }
    }
}
