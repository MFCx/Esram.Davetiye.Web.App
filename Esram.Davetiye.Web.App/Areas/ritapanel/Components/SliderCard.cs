using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Components
{
    public class SliderCard : ViewComponent
    {
        public IViewComponentResult Invoke(int sid = 0)
        {
            using var context = new EsramDbContext();
            var slider = new Slider();
            if (sid != 0)
                slider = context.Sliders.Find(sid);
            else
            {
                slider = context.Sliders.OrderBy(x => x.Index).FirstOrDefault();
            }
            return View("~/Areas/ritapanel/Views/ViewComponents/slidercard.cshtml", slider);
        }
    }
}
