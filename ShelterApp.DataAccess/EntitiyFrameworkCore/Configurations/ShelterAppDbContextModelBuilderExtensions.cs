﻿using Microsoft.EntityFrameworkCore;
using ShelterApp.Core.Extensions;
using ShelterApp.Entities.Entities.Blog;
using ShelterApp.Entities.Entities.Privilege;
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
                b.Property(t => t.Yazar).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Foto).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Language).IsRequired().HasColumnType("nvarchar(max)");

            });
        }
        public static void ConfigureProduct(this ModelBuilder builder)
        {
            builder.Entity<TBL_Product>(b =>
            {
                b.ToTable("TBL_Product");
                b.ConfigureByConvention();

                b.Property(t => t.Baslik).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Detay).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Isim).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Icerik).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.UstBaslik).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.FrontPhoto).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo1).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo2).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo3).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Language).IsRequired().HasColumnType("nvarchar(max)");

            });
        } 
        public static void ConfigureSector(this ModelBuilder builder)
        {
            builder.Entity<TBL_Sector>(b =>
            {
                b.ToTable("TBL_Sector");
                b.ConfigureByConvention();

                b.Property(t => t.ContentText).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.HeaderText).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.TextInPicture).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.SectorName).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Language).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.FrontPhoto).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo1).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo2).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo3).IsRequired(false).HasColumnType("nvarchar(max)");

            });
        }

        public static void ConfigurePrivilege(this ModelBuilder builder)
        {
            builder.Entity<TBL_Privilege>(b =>
            {
                b.ToTable("TBL_Privilege");
                b.ConfigureByConvention();

                b.Property(t => t.PrivilegeName).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.TextInPicture).IsRequired().HasColumnType("nvarchar(max)");
                b.Property(t => t.Photo).IsRequired(false).HasColumnType("nvarchar(max)");
                b.Property(t => t.Language).IsRequired().HasColumnType("nvarchar(max)");


            });
        }
    }
}
