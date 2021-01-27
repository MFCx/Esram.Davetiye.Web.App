using Esram.Davetiye.Web.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels
{
    public class CreateProductViewModel
    {
        public List<MasterCategory> MasterCategories { get; set; }
        public Product Product { get; set; }
    }
}
