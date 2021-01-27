using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Components
{
    public class HomeTabArea : ViewComponent
    {
        public IViewComponentResult Invoke(int mcid=0)
        {
            using var context = new EsramDbContext();
            mcid = mcid == 0 ? context.MasterCategories.FirstOrDefault().Id : mcid;
            var products = context.Products.Include(x=>x.Category).ThenInclude(x=>x.MasterCategory).Where(x => x.Category.MasterCategoryId == mcid).OrderByDescending(x => x.Id).Take(12).ToListAsync().Result;
            return View("~/Views/ViewComponents/hometabarea.cshtml",products);
        }
    }
}
