using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.ViewModels
{
    public class ContactViewModel
    {
        [DisplayName("Ad :")]
        [Required(ErrorMessage ="Ad alanı boş geçilemez")]
        public string Name { get; set; }
        [DisplayName("Email :")]
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        [DisplayName("Telefon :")]

        public string Phone { get; set; }
        [DisplayName("Konu :")]
        [Required(ErrorMessage = "Konu alanı boş geçilemez")]
        public string Subject { get; set; }
        [DisplayName("Mesaj :")]
        [Required(ErrorMessage = "Mesaj alanı boş geçilemez")]
        public string Message { get; set; }
    }
}
