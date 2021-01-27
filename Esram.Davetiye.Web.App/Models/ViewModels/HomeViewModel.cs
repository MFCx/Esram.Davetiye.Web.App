using Esram.Davetiye.Web.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<MasterCategory> MasterCategories { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
