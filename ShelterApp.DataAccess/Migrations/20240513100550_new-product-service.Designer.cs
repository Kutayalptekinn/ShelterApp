﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShelterApp.DataAccess.EntitiyFrameworkCore;

#nullable disable

namespace ShelterApp.DataAccess.Migrations
{
    [DbContext(typeof(ShelterAppDbContext))]
    [Migration("20240513100550_new-product-service")]
    partial class newproductservice
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShelterApp.Entities.Entities.Blog.TBL_Blog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Icerik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("DateTime");

                    b.Property<string>("Yazar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TBL_Blog", (string)null);
                });

            modelBuilder.Entity("ShelterApp.Entities.Entities.Product.TBL_Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Baslik")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("ID");

                    b.ToTable("TBL_Product", (string)null);
                });

            modelBuilder.Entity("ShelterApp.Entities.Entities.Sector.TBL_Service", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("ContentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Foto")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("HeaderText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TextInPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TBL_Service", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
