using Esram.Davetiye.Web.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels
{
    public class CategoryViewModel
    {
        public List<MasterCategory> MasterCategories { get; set; }
        public MasterCategory MasterCategory { get; set; }
    }
}
