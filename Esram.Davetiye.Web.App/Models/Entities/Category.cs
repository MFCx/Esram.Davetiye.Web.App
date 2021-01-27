using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int MasterCategoryId { get; set; }
        public virtual MasterCategory MasterCategory { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
