using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Manage.Sessions;
using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public async Task<IActionResult> Index()
        {
            using var context = new EsramDbContext();
            HomeViewModel vm = new HomeViewModel();
            vm.MasterCategories = await context.MasterCategories.ToListAsync();
            vm.Sliders = await context.Sliders.OrderBy(x => x.Index).ToListAsync();
            return View(vm);
        }
        
        [HttpPost]
        [Route("changetab")]
        public IActionResult ChangeTab(int mcid)
        {
            return ViewComponent("HomeTabArea", mcid);
        }

        [HttpPost]
        [Route("changeproductmodal")]
        public IActionResult ChangeProductModal(int pid)
        {
            return ViewComponent("ChangeProductModal", pid);
        }
    }
}
