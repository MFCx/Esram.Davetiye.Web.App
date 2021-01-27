using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Manage.Sessions;
using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Controllers
{
    public class CommonController : Controller
    {
        [Route("kurumsal")]
        public IActionResult Corporate()
        {
            return View();
        }

        [Route("iletisim")]
        public IActionResult Contact()
        {
            return View(new ContactViewModel());
        }

        [Route("sikca-sorulan-sorular")]
        public async Task<IActionResult> Faq()
        {
            using var context = new EsramDbContext();
            var faqs = await context.Faqs.OrderByDescending(x => x.Id).ToListAsync();
            return View(faqs);
        }

        [HttpPost]
        [Route("iletisim")]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.Credentials = new NetworkCredential("esramdavetiyeiletisimformu@gmail.com", "Rita2019.");
                    client.EnableSsl = true;
                    MailMessage msg = new MailMessage("esramdavetiyeiletisimformu@gmail.com", CorporateSession.Corporate.Email);
                    msg.IsBodyHtml = true;
                    msg.Subject = "Esram Davetiye İletişim Formu";
                    msg.Body = $"<b>Ad soyad: </b>{model.Name}<br/><b>Email: </b>{model.Email}<br/><b>Telefon: </b>{model.Phone}<br/><b>Konu: </b>{model.Subject}<br/><b>Mesaj: </b>{model.Message}";
                    client.Send(msg);
                    return RedirectToAction("Thanks");
                }
                catch (Exception)
                {
                    return RedirectToAction("Sorry");
                }
            }
            return View(model);
        }

        [Route("tesekkurler")]
        public IActionResult Thanks()
        {
            return View();
        }

        [Route("bir-hata-olustu")]
        public IActionResult Sorry()
        {
            return View();
        }
    }
}
