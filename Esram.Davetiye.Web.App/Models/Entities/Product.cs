using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Ürün adı : ")]
        [Required(ErrorMessage ="Ürün adı boş geçilemez")]
        public string Name { get; set; }
        [DisplayName("Ürün kodu : ")]
        [Required(ErrorMessage ="Ürün kodu boş geçilemez")]
        public string Code { get; set; }
        [DisplayName("Ürün açıklaması : ")]
        public string Description { get; set; }
        [DisplayName("Kapak resmi : ")]
        public string MainPicture { get; set; }
        [DisplayName("Çok tercih edilen olarak işaretle : ")]
        public bool IsBest { get; set; }
        [DisplayName("Fiyat : ")]
        public string Price { get; set; }
        [DisplayName("Kategori : ")]
        [Required(ErrorMessage ="Lütfen kategori seçiniz")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [DisplayName("Diğer resimler :")]
        public virtual ICollection<ProductPicture> Pictures { get; set; }
    }
}
