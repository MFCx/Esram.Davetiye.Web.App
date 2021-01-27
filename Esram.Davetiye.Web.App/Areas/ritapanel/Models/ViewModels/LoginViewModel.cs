using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı adı: ")]
        public string Username { get; set; }
        [DisplayName("Şifre: ")]
        public string Password { get; set; }
    }
}
