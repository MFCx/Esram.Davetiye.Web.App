using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        [DisplayName("Mevcut şifre")]
        [Required(ErrorMessage ="Mevcut şifre boş geçilemez")]
        public string CurrentPassword { get; set; }
        [Required(ErrorMessage ="Yeni şifre boş geçilemez")]
        [DisplayName("Yeni şifre")]
        public string Password { get; set; }
        [DisplayName("Yeni şifre tekrar")]
        [Required(ErrorMessage ="Yeni şifre tekrar boş geçilemez")]
        [Compare("Password",ErrorMessage ="Yeni şifreler eşleşmiyor")]
        public string ConfirmPassword { get; set; }
    }
}
