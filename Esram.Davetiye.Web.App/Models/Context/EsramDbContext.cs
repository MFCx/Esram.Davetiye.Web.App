using Esram.Davetiye.Web.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esram.Davetiye.Web.App.Models.Context
{
    public class EsramDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=94.73.145.9;Initial Catalog=u9243568_esramdb; User Id=u9243568_esramdb;Password=PEkm47F9HOya18U;");
        }

        public DbSet<MasterCategory> MasterCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
    }
}
