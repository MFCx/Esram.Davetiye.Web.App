using Esram.Davetiye.Web.App.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Components
{
    public class HomeBestArea : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var context = new EsramDbContext();
            var bests = context.Products.Include(x=>x.Category).ThenInclude(x=>x.MasterCategory).Where(x => x.IsBest).OrderByDescending(x=>x.Id).ToListAsync().Result;
            return View("~/Views/ViewComponents/homebestarea.cshtml",bests);
        }
    }
}
