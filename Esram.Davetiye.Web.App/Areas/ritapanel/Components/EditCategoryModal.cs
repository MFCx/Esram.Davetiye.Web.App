using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Components
{
    public class EditCategoryModal : ViewComponent
    {
        public IViewComponentResult Invoke(Category cat)
        {
            return View("~/Areas/ritapanel/Views/ViewComponents/editcategorymodal.cshtml", cat);
        }
    }
}
