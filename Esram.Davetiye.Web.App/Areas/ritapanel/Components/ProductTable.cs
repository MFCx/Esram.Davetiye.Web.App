using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Components
{
    public class ProductTable : ViewComponent
    {
        public IViewComponentResult Invoke(int mcid=0,int cid=0)
        {
            using var context = new EsramDbContext();
            List<Product> products = context.Products.Include(x=>x.Category).OrderByDescending(x=>x.Id).ToListAsync().Result;
            if (mcid != 0)
                products = products.Where(x => x.Category.MasterCategoryId == mcid).ToList();
            if(cid!=0)
                products = products.Where(x => x.CategoryId == cid).ToList();
                
            return View("~/Areas/ritapanel/Views/ViewComponents/producttable.cshtml", products);
        }
    }
}
