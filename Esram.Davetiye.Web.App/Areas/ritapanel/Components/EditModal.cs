using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Components
{
    public class EditModal : ViewComponent
    {
        public IViewComponentResult Invoke(MasterCategory mc)
        {
            return View("~/Areas/ritapanel/Views/ViewComponents/editmodal.cshtml",mc);
        }
    }
}
