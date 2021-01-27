using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels;
using Esram.Davetiye.Web.App.Manage.Filters;
using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.Entities;
using Esram.Davetiye.Web.App.Models.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Controllers
{
    [Authentication]
    [Area("ritapanel")]
    public class ProductController : Controller
    {
        [Route("ritapanel/davetiyeler")]
        public async Task<IActionResult> Index()
        {
            using var context = new EsramDbContext();
            var mcs = await context.MasterCategories.Include(m => m.Categories).ToListAsync();
            return View(mcs);
        }

        [HttpPost]
        [Route("getcatbymaster")]
        public async Task<IActionResult> GetCategoriesByMaster(int mcid)
        {
            using var context = new EsramDbContext();
            var cats = await context.Categories.Where(x => x.MasterCategoryId == mcid).OrderByDescending(x => x.Id).ToListAsync();
            return Json(cats);
        }

        [HttpPost]
        [Route("changeproductlist")]
        public IActionResult ChangeProductList(int mcid, int cid)
        {
            return ViewComponent("ProductTable", new { mcid = mcid, cid = cid });
        }

        [Route("ritapanel/urun-guncelle/{id}")]
        public async Task<IActionResult> EditProduct(int id)
        {
            using var context = new EsramDbContext();
            var product = await context.Products.Include(x => x.Pictures).FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        [Route("ritapanel/urun-guncelle/{id}")]
        public async Task<IActionResult> EditProduct(Product product)
        {
            using var context = new EsramDbContext();
            var current = await context.Products.Include(x => x.Pictures).FirstOrDefaultAsync(x => x.Id == product.Id);
            if (ModelState.IsValid)
            {
                current.Name = product.Name;
                current.IsBest = product.IsBest;
                current.MainPicture = product.MainPicture;
                current.Code = product.Code;
                current.Price = product.Price;
                current.Description = product.Description;
                context.Products.Update(current);
                int result = await context.SaveChangesAsync();

                if (result > 0)
                {
                    ViewBag.Success = "Ürün başarıyla güncellendi";
                }
                else
                {
                    ViewBag.Error = "Ürün güncellenirken bir hata oluştu";
                }
            }
            return View(current);
        }

        [HttpPost]
        [Route("delete-gallery")]
        public async Task<IActionResult> DeleteGallery(int gid)
        {
            using var context = new EsramDbContext();
            ProductPicture pic = await context.ProductPictures.FindAsync(gid);
            context.ProductPictures.Remove(pic);
            FileExtension.RemoveFile(pic.Path);
            int result = await context.SaveChangesAsync();
            return Json(result > 0);
        }

        [HttpPost]
        [Route("edit-pictures")]
        public async Task<IActionResult> EditPictures(IFormFile MainPicture, List<IFormFile> Pictures, int productId)
        {
            using var context = new EsramDbContext();
            Product prod = await context.Products.FindAsync(productId);
            if (MainPicture != null)
            {
                if (prod.MainPicture != null)
                    FileExtension.RemoveFile(prod.MainPicture);
                prod.MainPicture = FileExtension.UploadFile(MainPicture, "wwwroot/static/uploads/products").Replace(@"\", "/");
                context.Products.Update(prod);
            }
            if (Pictures.Count > 0)
            {
                List<ProductPicture> pList = new List<ProductPicture>();
                foreach (var pic in Pictures)
                {
                    pList.Add(new ProductPicture
                    {
                        Path = FileExtension.UploadFile(pic, "wwwroot/static/uploads/products").Replace(@"\", "/"),
                        ProductId = productId
                    });
                }
                await context.ProductPictures.AddRangeAsync(pList);
            }
            await context.SaveChangesAsync();
            return RedirectToAction("EditProduct", prod);
        }

        [HttpPost]
        [Route("delete-product")]
        public async Task<IActionResult> DeleteProduct(int pid)
        {
            using var context = new EsramDbContext();
            var prod = await context.Products.FindAsync(pid);
            context.Products.Remove(prod);
            int result = await context.SaveChangesAsync();
            return Json(result > 0);
        }

        [Route("ritapanel/urun-ekle")]
        public IActionResult CreateProduct()
        {
            using var context = new EsramDbContext();
            CreateProductViewModel vm = new CreateProductViewModel();
            vm.Product = new Product();
            vm.MasterCategories = context.MasterCategories.Include(x => x.Categories).ToList();
            return View(vm);
        }
        [HttpPost]
        [Route("ritapanel/urun-ekle")]
        public async Task<IActionResult> CreateProduct(Product product, IFormFile MainPicture, List<IFormFile> Pictures)
        {
            CreateProductViewModel vm = new CreateProductViewModel();
            using var context = new EsramDbContext();
            vm.MasterCategories = context.MasterCategories.Include(x => x.Categories).ToList();
            vm.Product = new Product();
            if (ModelState.IsValid)
            {
                product.MainPicture = FileExtension.UploadFile(MainPicture, "wwwroot/static/uploads/products").Replace(@"\", "/");

                if (Pictures.Count > 0)
                {
                    product.Pictures = new List<ProductPicture>();
                    foreach (var item in Pictures)
                    {
                        product.Pictures.Add(new ProductPicture
                        {
                            Path = FileExtension.UploadFile(item, "wwwroot/static/uploads/products").Replace(@"\", "/")
                        });
                    }
                }

                await context.Products.AddAsync(product);
                int result = await context.SaveChangesAsync();
                ViewBag.Success = "Ürün başarıyla eklendi";
                return View(vm);
            }
            return View(vm);
        }
    }
}
