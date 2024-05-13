using Microsoft.EntityFrameworkCore;
using ShelterApp.Core.Extensions;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Product;
using ShelterApp.Entities.Entities.Sector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShelterApp.DataAccess.EntitiyFrameworkCore.Configurations
{
    public static class ShelterAppDbContextModelBuilderExtensions
    {
        public static void ConfigureBlog(this ModelBuilder builder)
        {
            builder.Entity<TBL_Blog>(b =>
            {
                b.ToTable("TBL_Blog");
                b.ConfigureByConvention();

                b.Property(t => t.Konu).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Baslik).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Icerik).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Tarih).HasColumnType(SqlDbType.DateTime.ToString());
                b.Property(t => t.Yazar).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Foto).HasColumnType("varbinary(max)");

            });
        }
        public static void ConfigureProduct(this ModelBuilder builder)
        {
            builder.Entity<TBL_Product>(b =>
            {
                b.ToTable("TBL_Product");
                b.ConfigureByConvention();

                b.Property(t => t.Baslik).IsRequired().HasColumnType("nvarchar(max)");
              
                b.Property(t => t.Foto).HasColumnType("varbinary(max)");

            });
        } 
        public static void ConfigureService(this ModelBuilder builder)
        {
            builder.Entity<TBL_Service>(b =>
            {
                b.ToTable("TBL_Service");
                b.ConfigureByConvention();

                b.Property(t => t.ContentText).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.HeaderText).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.TextInPicture).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.ServiceName).IsRequired().HasColumnType("nvarchar(max)");
              
                b.Property(t => t.Foto).HasColumnType("varbinary(max)");

            });
        }
    }
}
