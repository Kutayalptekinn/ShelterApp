
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShelterApp.DataAccess.EntitiyFrameworkCore.Configurations;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Privilege;
using ShelterApp.Entities.Entities.Product;
using ShelterApp.Entities.Entities.Sector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore
{
    public class ShelterAppDbContext: DbContext
    {
        public IConfigurationRoot _configuration;
        public virtual string BasePath { get; set; }
        public virtual string ConnectionStringKey { get; set; }

        public virtual string JsonFile { get; set; }

        public ShelterAppDbContext()
        {
            this.BasePath = Directory.GetCurrentDirectory();
            this.JsonFile = "appsettings.json";
            this.ConnectionStringKey = "AppConnectionString";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(BasePath)
                 .AddJsonFile(JsonFile)
                 .Build();
            
            if (configuration != null)
            {
                _configuration = configuration;
            }


            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(ConnectionStringKey));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ConfigureBlog();
            builder.ConfigureProduct();
            builder.ConfigureSector();
            builder.ConfigurePrivilege();
         }
        public DbSet<TBL_Blog> TBL_Bloglar { get; set; }
        public DbSet<TBL_Product> TBL_Products { get; set; }
        public DbSet<TBL_Sector> TBL_Sectors { get; set; }
        public DbSet<TBL_Privilege> TBL_Privileges { get; set; }
    }
}
