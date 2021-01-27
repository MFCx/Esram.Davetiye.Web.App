using Esram.Davetiye.Web.App.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Components
{
    public class ChangeProductModal : ViewComponent
    {
        public IViewComponentResult Invoke(int productId)
        {
            using var context = new EsramDbContext();
            var p = context.Products.Include(x=>x.Pictures).Include(x=>x.Category).FirstOrDefault(p=>p.Id==productId);
            return View("~/Views/ViewComponents/productmodal.cshtml",p);
        }
    }
}
