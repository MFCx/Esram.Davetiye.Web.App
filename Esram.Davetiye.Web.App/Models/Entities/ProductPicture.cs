using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Entities
{
    public class ProductPicture
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
