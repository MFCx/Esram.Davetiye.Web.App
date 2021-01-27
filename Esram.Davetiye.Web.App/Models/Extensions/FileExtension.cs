using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Extensions
{
    public enum FileType
    {
        Jpg, Png, Pdf, Jpeg
    }
    public static class FileExtension
    {
        public static string UploadFile(IFormFile file, string path)
        {
            // TODO : File upload

            string fileName = Path.GetFileNameWithoutExtension(file.FileName) + Guid.NewGuid().ToString().Substring(0, 4) + Path.GetExtension(file.FileName);
            string SavePath = Path.Combine(Directory.GetCurrentDirectory(), path, fileName);

            using (var stream = new FileStream(SavePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return Path.Combine(path.Remove(0,8), fileName);
        }

        public static void RemoveFile(string fileName)
        {
            File.Delete("wwwroot/"+fileName);
        }
    }
}
