using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Esram.Davetiye.Web.App.Areas.ritapanel.Models.ViewModels;
using Esram.Davetiye.Web.App.Manage.Filters;
using Esram.Davetiye.Web.App.Models.Context;
using Esram.Davetiye.Web.App.Models.Entities;
using Esram.Davetiye.Web.App.Models.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace Esram.Davetiye.Web.App.Areas.ritapanel.Controllers
{
    [Authentication]
    [Area("ritapanel")]
    public class CategoryController : Controller
    {
        [Route("ritapanel/kategoriler")]
        public async Task<IActionResult> Index()
        {
            using var context = new EsramDbContext();
            var categories = await context.MasterCategories.Include(x => x.Categories).OrderByDescending(x=>x.Id).ToListAsync();
            CategoryViewModel vm = new CategoryViewModel
            {
                MasterCategories = categories,
                MasterCategory = new MasterCategory()
            };
            return View(vm);
        }

        [HttpPost]
        [Route("addmaster")]
        public async Task<IActionResult> AddMasterCategory(MasterCategory masterCategory,IFormFile McPicturePath)
        {
            if (McPicturePath!=null)
                masterCategory.PicturePath = FileExtension.UploadFile(McPicturePath, "wwwroot/static/uploads/categories").Replace(@"\", "/");
            using var context = new EsramDbContext();
            context.MasterCategories.Add(masterCategory);
            int result = await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("deletemaster")]
        public async Task<IActionResult> DeleteMasterCategory(int id)
        {
            using var context = new EsramDbContext();
            var mc = await context.MasterCategories.FirstOrDefaultAsync(x => x.Id == id);
            context.MasterCategories.Remove(mc);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("editmodal")]
        public async Task<IActionResult> EditModal(int mcid)
        {
            using var context = new EsramDbContext();
            var mc = await context.MasterCategories.FirstOrDefaultAsync(x => x.Id == mcid);
            return ViewComponent("EditModal", mc);
        }

        [HttpPost]
        [Route("editcategorymodal")]
        public async Task<IActionResult> EditCategoryModal(int cid)
        {
            using var context = new EsramDbContext();
            var cat = await context.Categories.FirstOrDefaultAsync(x => x.Id == cid);
            return ViewComponent("EditCategoryModal", cat);
        }

        [HttpPost]
        [Route("editcategory")]
        public async Task<IActionResult> EditCategory(Category cat, IFormFile PicturePath)
        {
            if (PicturePath != null)
                cat.PicturePath = FileExtension.UploadFile(PicturePath, "wwwroot/static/uploads/categories").Replace(@"\", "/");
            using var context = new EsramDbContext();
            context.Categories.Update(cat);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("editmaster")]
        public async Task<IActionResult> EditMasterCategory(MasterCategory mc,IFormFile PicturePath)
        {
            if (PicturePath != null)
                mc.PicturePath = FileExtension.UploadFile(PicturePath, "wwwroot/static/uploads/categories").Replace(@"\", "/");
            using var context = new EsramDbContext();
            context.MasterCategories.Update(mc);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Route("deletecategory")]
        public async Task<IActionResult> DeleteCategory(int cid)
        {
           
                using var context = new EsramDbContext();
                var cat = await context.Categories.FirstOrDefaultAsync(x => x.Id == cid);
                context.Categories.Remove(cat);
                int result = await context.SaveChangesAsync();
                return result>0?Json(true):Json(false);
        }

        [HttpPost]
        [Route("addcategorymodal")]
        public IActionResult AddCategoryModal(int mcid)
        {
            var cat = new Category
            {
                MasterCategoryId = mcid
            };
            return ViewComponent("AddCategoryModal", cat);
        }

        [HttpPost]
        [Route("addcategory")]
        public async Task<IActionResult> AddCategory(Category category,IFormFile PicturePath)
        {
            using var context = new EsramDbContext();
            if (PicturePath != null)
                category.PicturePath = FileExtension.UploadFile(PicturePath, "wwwroot/static/uploads/categories").Replace(@"\", "/");
            context.Categories.Add(category);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
