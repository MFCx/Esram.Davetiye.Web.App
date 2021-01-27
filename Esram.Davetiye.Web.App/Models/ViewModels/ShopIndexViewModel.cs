using Esram.Davetiye.Web.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.ViewModels
{
    public class ShopIndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<MasterCategory> MasterCategories { get; set; }
    }
}
