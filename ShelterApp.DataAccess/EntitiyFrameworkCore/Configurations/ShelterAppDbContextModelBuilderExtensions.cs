using Microsoft.EntityFrameworkCore;
using ShelterApp.Core.Extensions;
using ShelterApp.Entities.Entities.Blog;
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
    }
}
