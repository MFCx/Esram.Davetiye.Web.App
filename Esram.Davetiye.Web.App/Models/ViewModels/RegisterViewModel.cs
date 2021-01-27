using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Fullname { get; set; }
        [DisplayName("Şifre")]
        public string Password { get; set; }
        [DisplayName("Şifre Tekrar")]
        [Compare("Password",ErrorMessage ="Şifreler aynı değil")]
        public string ConfirmPassword { get; set; }
    }
}
