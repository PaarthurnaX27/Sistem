﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations.SmSec
{
    [DbContext(typeof(SmSecContext))]
    [Migration("20230126064053_mig_12")]
    partial class mig12
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EntityLayer.Concrete.Kullanici", b =>
                {
                    b.Property<int>("KullaniciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KullaniciId"));

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciFirma")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciParola")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("KullaniciSoyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("KullaniciId");

                    b.ToTable("Kullanicis");
                });

            modelBuilder.Entity("EntityLayer.Concrete.KullaniciFirma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int>("KullaniciId")
                        .HasColumnType("integer");

                    b.Property<int?>("SecCmpCompanyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("KullaniciId");

                    b.HasIndex("SecCmpCompanyId");

                    b.ToTable("KullaniciFirmas");
                });

            modelBuilder.Entity("EntityLayer.Concrete.SecCmp", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompanyId"));

                    b.Property<DateTime>("BeginDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("CompanyNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DatabaseName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ServerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.HasKey("CompanyId");

                    b.ToTable("SecCmps");
                });

            modelBuilder.Entity("EntityLayer.Concrete.KullaniciFirma", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Kullanici", "Kullanici")
                        .WithMany()
                        .HasForeignKey("KullaniciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.SecCmp", "SecCmp")
                        .WithMany()
                        .HasForeignKey("SecCmpCompanyId");

                    b.Navigation("Kullanici");

                    b.Navigation("SecCmp");
                });
#pragma warning restore 612, 618
        }
    }
}
