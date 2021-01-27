using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Controllers
{
    public class ShopController : Controller
    {
        [Route("davetiyeler/{mastercategory}/kategori/{category}/{pageIndex?}")]
        public async Task<IActionResult> ShopByCategory(string mastercategory,string category,int pageIndex=1)
        {
            using var context = new EsramDbContext();
            ShopIndexViewModel vm = new ShopIndexViewModel();
            vm.Products = await context.Products.Where(x => x.Category.Name == category).OrderByDescending(x => x.Id).Skip((pageIndex - 1) * 12).Take(12).ToListAsync();
            vm.MasterCategories = await context.MasterCategories.Include(x => x.Categories).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.MasterCategory = mastercategory;
            ViewBag.Category = category;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = Math.Ceiling(Convert.ToDouble(await context.Products.Where(x => x.Category.Name == category).CountAsync()) / Convert.ToDouble(12));
            return View("~/Views/Shop/Index.cshtml",vm);
        }

        [Route("davetiyeler/{mastercategory}/{pageIndex?}")]
        public async Task<IActionResult> ShopByMasterCategory(string mastercategory, int pageIndex=1)
        {
            using var context = new EsramDbContext();
            ShopIndexViewModel vm = new ShopIndexViewModel();
            vm.Products = await context.Products.Where(x => x.Category.MasterCategory.Name == mastercategory).OrderByDescending(x => x.Id).Skip((pageIndex - 1) * 12).Take(12).ToListAsync();
            vm.MasterCategories = await context.MasterCategories.Include(x => x.Categories).OrderByDescending(x => x.Id).ToListAsync();
            ViewBag.MasterCategory = mastercategory;
            ViewBag.PageIndex = pageIndex;
            ViewBag.PageCount = Math.Ceiling(Convert.ToDouble(await context.Products.Where(x => x.Category.MasterCategory.Name == mastercategory).CountAsync()) / Convert.ToDouble(12));
            return View("~/Views/Shop/Index.cshtml",vm);
        }

        [Route("davetiyeler/{mastercategory}/{category}/{code}")]
        public async Task<IActionResult> SingleProduct(string code)
        {
            using var context = new EsramDbContext();
            var prod = await context.Products.Include(x=>x.Pictures).Include(x=>x.Category).ThenInclude(x=>x.MasterCategory).FirstOrDefaultAsync(x => x.Code == code);
            return View(prod);
        }
    }
}
