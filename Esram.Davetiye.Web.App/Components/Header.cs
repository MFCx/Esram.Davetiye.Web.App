using Esram.Davetiye.Web.App.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Components
{
    public class Header : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var context = new EsramDbContext();
            var mcs = context.MasterCategories.Include(x => x.Categories).OrderBy(x => x.Index).ToList();
            return View("~/Views/Shared/header.cshtml",mcs);
        }
    }
}
