using Esram.Davetiye.Web.App.Models.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Entities
{
    public class ApplicationUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez: ")]
        [DisplayName("Kullanıcı adı: ")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez: ")]
        [DisplayName("Ad soyad: ")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez: ")]
        [DisplayName("Şifre: ")]
        public string Password { get; set; }
    }
}
