using Esram.Davetiye.Web.App.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Components
{
    public class Footer : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var context = new EsramDbContext();
            var mcs = context.MasterCategories.Include(x => x.Categories).OrderByDescending(x => x.Id).ToList();
            return View("~/Views/Shared/footer.cshtml",mcs);
        }
    }
}
