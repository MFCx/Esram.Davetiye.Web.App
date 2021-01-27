using Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Components
{
    public class Navbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("~/Areas/ritapanel/Views/ViewComponents/navbar.cshtml",new ChangePasswordViewModel());
        }
    }
}
