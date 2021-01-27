using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Entities
{
    public class Corporate
    {
        [DisplayName("Firma adı :")]
        [Required(ErrorMessage ="Firma boş geçilemez")]
        public string CompanyName { get; set; }
        [DisplayName("Harita Yerleştirme Kodu (iframe içerisinden sadece src kısmını yazınız):")]
        public string MapCode { get; set; }
        [DisplayName("Hakkımızda :")]
        [Required(ErrorMessage ="Hakkımızda alanı boş geçilemez")]
        public string AboutText { get; set; }
        [DisplayName("Firma logosu :")]
        public string LogoPath { get; set; }
        [DisplayName("İnstagram linki (https://instagram.com/firmaniz) :")]
        public string Instagram { get; set; }
        [DisplayName("Facebook linki (https://facebook.com/firmaniz) :")]
        public string Facebook { get; set; }
        [DisplayName("Whatsapp no (+905555555555) :")]
        public string Whatsapp { get; set; }
        [DisplayName("Telefon no (+903121112233) :")]
        public string Phone { get; set; }
        [DisplayName("Adres :")]
        [Required(ErrorMessage ="Adres alanı boş geçilemez")]
        public string Address { get; set; }
        [DisplayName("Email :")]
        [Required(ErrorMessage = "Email alanı boş geçilemez")]
        public string Email { get; set; }
        [DisplayName("Kampanya görseli :")]
        public string CampaignPath { get; set; }
        [DisplayName("Sayfa linki (https://www.domaininiz.com/sayfa):")]
        public string CampaignUrl { get; set; }
        [DisplayName("Kampanya görseli küçük yazı :")]
        public string CampaignSmallText { get; set; }
        [DisplayName("Kampanya görseli büyük yazı :")]
        public string CampaignBigText { get; set; }
        [DisplayName("Kampanya yazı rengi :")]
        public string CampaignTextColor { get; set; }
        [DisplayName("Site iconu : ")]
        public string IconPath { get; set; }
    }
}
