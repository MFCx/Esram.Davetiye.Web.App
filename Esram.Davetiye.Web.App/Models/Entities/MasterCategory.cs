using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Entities
{
    public class MasterCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PicturePath { get; set; }
        public int Index { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
