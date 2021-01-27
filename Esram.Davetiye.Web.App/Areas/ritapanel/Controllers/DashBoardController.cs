using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Esram.Davetiye.Web.App.Manage.Filters;
using Esram.Davetiye.Web.App.Manage.Sessions;
using Esram.Davetiye.Web.App.Models.Entities;
using Esram.Davetiye.Web.App.Models.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Controllers
{
    [Authentication]
    [Area("ritapanel")]
    public class DashBoardController : Controller
    {
        [Route("ritapanel")]
        public IActionResult Index()
        {
            return View(CorporateSession.Corporate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("ritapanel")]
        public IActionResult Index(Corporate corporate,IFormFile LogoPath,IFormFile IconPath, IFormFile CampaignPath)
        {
            corporate.LogoPath = CorporateSession.Corporate.LogoPath;
            corporate.IconPath = CorporateSession.Corporate.IconPath;
            corporate.CampaignPath = CorporateSession.Corporate.CampaignPath;
            //corporate.AboutText = "![CDATA["+corporate.AboutText+"]";

            if (ModelState.IsValid)
            {
                if (LogoPath!=null)
                   corporate.LogoPath = FileExtension.UploadFile(LogoPath, "wwwroot/static/uploads/corporate").Replace(@"\", "/");
                if(IconPath!=null)
                   corporate.IconPath = FileExtension.UploadFile(IconPath, "wwwroot/static/uploads/corporate").Replace(@"\", "/");
                if(CampaignPath!=null)
                   corporate.CampaignPath = FileExtension.UploadFile(CampaignPath, "wwwroot/static/uploads/corporate").Replace(@"\", "/");

                FileStream stream = new FileStream("wwwroot/corporate.xml", FileMode.Create, FileAccess.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(typeof(Corporate), new XmlRootAttribute { ElementName = "Corporate", Namespace = "www.ritabilisim.com" });
                serializer.Serialize(stream, corporate);
                stream.Close();
                CorporateSession.Corporate = corporate;
            }
            return View(corporate);
        }
    }
}
