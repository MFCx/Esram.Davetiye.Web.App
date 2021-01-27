using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Manage.Filters;
using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.Entities;
using Esram.Davetiye.Web.App.Models.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Controllers
{
    [Authentication]
    [Area("ritapanel")]
    public class SliderController : Controller
    {
        [Route("ritapanel/slider")]
        public async Task<IActionResult> Index()
        {
            using var context = new EsramDbContext();
            var sliders = await context.Sliders.OrderBy(x => x.Index).ToListAsync();
            return View(sliders);
        }

        [HttpPost]
        [Route("changeslidercard")]
        public IActionResult ChangeSliderCard(int sid)
        {
            return ViewComponent("SliderCard", sid);
        }

        [HttpPost]
        [Route("deleteslider")]
        public async Task<IActionResult> DeleteSlider(int sid)
        {
            using var context = new EsramDbContext();
            var slider = await context.Sliders.FirstOrDefaultAsync(x => x.Id == sid);
            context.Sliders.Remove(slider);
            int result = await context.SaveChangesAsync();
            if (result>0)
            {
                FileExtension.RemoveFile(slider.Path);
                return Json(true);
            }
            return Json(false);
        }

        [HttpPost]
        [Route("editslider")]
        public async Task<IActionResult> EditSlider(int id,int index, IFormFile path,string currentpath)
        {
            using var context = new EsramDbContext();
            var slider = await context.Sliders.FindAsync(id);
            slider.Index = index;
            if (path != null)
                slider.Path = FileExtension.UploadFile(path, "wwwroot/static/uploads/sliders").Replace(@"\", "/");
            context.Sliders.Update(slider);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("newslider")]
        public async Task<IActionResult> NewSlider(int index, IFormFile path)
        {
            using var context = new EsramDbContext();
            var slider = new Slider
            {
                Index = index,
                Path = FileExtension.UploadFile(path, "wwwroot/static/uploads/sliders").Replace(@"\","/")
            };
            context.Sliders.Add(slider);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
