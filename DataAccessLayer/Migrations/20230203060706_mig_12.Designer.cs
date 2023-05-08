﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(SmServisContext))]
    [Migration("20230203060706_mig_12")]
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

            modelBuilder.Entity("EntityLayer.Concrete.AnaSektor", b =>
                {
                    b.Property<int>("AnaSektorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AnaSektorId"));

                    b.Property<string>("AnaSektorAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("AnaSektorId");

                    b.ToTable("AnaSektors");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AnaSektor_BagliSektor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AnaSektorId")
                        .HasColumnType("integer");

                    b.Property<int>("BagliSektorId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AnaSektorId");

                    b.HasIndex("BagliSektorId");

                    b.ToTable("AnaSektor_BagliSektors");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BagliSektor", b =>
                {
                    b.Property<int>("BagliSektorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("BagliSektorId"));

                    b.Property<int>("AnaSektorId")
                        .HasColumnType("integer");

                    b.Property<string>("BagliSektorAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BagliSektorId");

                    b.HasIndex("AnaSektorId");

                    b.ToTable("BagliSektors");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Cari", b =>
                {
                    b.Property<int>("CariId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CariId"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("AnaSektorId")
                        .HasColumnType("integer");

                    b.Property<int?>("BagliSektorId")
                        .HasColumnType("integer");

                    b.Property<string>("CariDil")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CariDurumId")
                        .HasColumnType("integer");

                    b.Property<int>("CariTipiId")
                        .HasColumnType("integer");

                    b.Property<int>("FirmaNo")
                        .HasColumnType("integer");

                    b.Property<string>("HesapKodu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IlceId")
                        .HasColumnType("integer");

                    b.Property<string>("MailAdresi1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MailAdresi2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ParaBirimiId")
                        .HasColumnType("integer");

                    b.Property<int>("SehirId")
                        .HasColumnType("integer");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Telefon1")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UlkeId")
                        .HasColumnType("integer");

                    b.Property<int>("UnvanId")
                        .HasColumnType("integer");

                    b.Property<string>("VergiDairesi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("VergiNo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebSitesi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("eFaturaMukellefi")
                        .HasColumnType("boolean");

                    b.Property<bool>("eIrsaliyeMukellefi")
                        .HasColumnType("boolean");

                    b.HasKey("CariId");

                    b.HasIndex("AnaSektorId");

                    b.HasIndex("BagliSektorId");

                    b.HasIndex("CariDurumId");

                    b.HasIndex("CariTipiId");

                    b.HasIndex("IlceId");

                    b.HasIndex("ParaBirimiId");

                    b.HasIndex("SehirId");

                    b.HasIndex("UlkeId");

                    b.HasIndex("UnvanId");

                    b.ToTable("Caris");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CariDurum", b =>
                {
                    b.Property<int>("CariDurumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CariDurumId"));

                    b.Property<string>("CariDurumAciklama")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CariDurumId");

                    b.ToTable("CariDurums");
                });

            modelBuilder.Entity("EntityLayer.Concrete.CariTipi", b =>
                {
                    b.Property<int>("CariTipiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CariTipiId"));

                    b.Property<string>("CariTipiAciklama")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CariTipiId");

                    b.ToTable("CariTipis");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Cinsiyet", b =>
                {
                    b.Property<int>("CinsiyetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CinsiyetId"));

                    b.Property<string>("CinsiyetAciklama")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CinsiyetId");

                    b.ToTable("Cinsiyets");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Departman", b =>
                {
                    b.Property<int>("DepartmanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("DepartmanId"));

                    b.Property<string>("DepartmanAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("DepartmanId");

                    b.ToTable("Departmans");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Ilce", b =>
                {
                    b.Property<int>("IlceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IlceId"));

                    b.Property<string>("IlceAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PostaKodu")
                        .HasColumnType("text");

                    b.Property<int>("SehirId")
                        .HasColumnType("integer");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IlceId");

                    b.HasIndex("SehirId");

                    b.ToTable("Ilces");
                });

            modelBuilder.Entity("EntityLayer.Concrete.IlgiliKisiler", b =>
                {
                    b.Property<int>("IlgiliKisiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IlgiliKisiId"));

                    b.Property<string>("IlgiliKisiAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiCinsiyet")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiDahiliTelefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiDepartman")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiDurumu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiKullaniciAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiMail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IlgiliKisiNo")
                        .HasColumnType("integer");

                    b.Property<string>("IlgiliKisiParola")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiPozisyon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiSoyadi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IlgiliKisiTelefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("IlgiliKisiId");

                    b.ToTable("IlgiliKisilers");
                });

            modelBuilder.Entity("EntityLayer.Concrete.ParaBirimi", b =>
                {
                    b.Property<int>("ParaBirimiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ParaBirimiId"));

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ParaBirimiAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParaBirimiKisaltma")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ParaBirimiSimge")
                        .HasColumnType("text");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("ParaBirimiId");

                    b.ToTable("ParaBirimis");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Pozisyon", b =>
                {
                    b.Property<int>("PozisyonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PozisyonId"));

                    b.Property<int>("DepartmanId")
                        .HasColumnType("integer");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PozisyonAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("PozisyonId");

                    b.HasIndex("DepartmanId");

                    b.ToTable("Pozisyons");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Sehir", b =>
                {
                    b.Property<int>("SehirId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SehirId"));

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("PlakaKodu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PostaKodu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SehirAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TelefonKodu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UlkeId")
                        .HasColumnType("integer");

                    b.HasKey("SehirId");

                    b.HasIndex("UlkeId");

                    b.ToTable("Sehirs");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Sube", b =>
                {
                    b.Property<int>("SubeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SubeId"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Sehir")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefon2")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Ulke")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("WebSite")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SubeId");

                    b.ToTable("Subes");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Ulke", b =>
                {
                    b.Property<int>("UlkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UlkeId"));

                    b.Property<string>("BinaryCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("TelefonKodu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TripleCode")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UlkeAdi")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UlkeId");

                    b.ToTable("Ulkes");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Unvan", b =>
                {
                    b.Property<int>("UnvanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UnvanId"));

                    b.Property<int>("Olusturan")
                        .HasColumnType("integer");

                    b.Property<DateTime>("OlusturulmaTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Silindi")
                        .HasColumnType("boolean");

                    b.Property<int>("SonDegistiren")
                        .HasColumnType("integer");

                    b.Property<DateTime>("SonDegistirmeTarih")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("UnvanAciklama")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UnvanKisaltma")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UnvanId");

                    b.ToTable("Unvans");
                });

            modelBuilder.Entity("EntityLayer.Concrete.AnaSektor_BagliSektor", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AnaSektor", "AnaSektor")
                        .WithMany()
                        .HasForeignKey("AnaSektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.BagliSektor", "BagliSektor")
                        .WithMany()
                        .HasForeignKey("BagliSektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnaSektor");

                    b.Navigation("BagliSektor");
                });

            modelBuilder.Entity("EntityLayer.Concrete.BagliSektor", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AnaSektor", "AnaSektor")
                        .WithMany()
                        .HasForeignKey("AnaSektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnaSektor");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Cari", b =>
                {
                    b.HasOne("EntityLayer.Concrete.AnaSektor", "AnaSektor")
                        .WithMany()
                        .HasForeignKey("AnaSektorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.BagliSektor", "BagliSektor")
                        .WithMany()
                        .HasForeignKey("BagliSektorId");

                    b.HasOne("EntityLayer.Concrete.CariDurum", "CariDurum")
                        .WithMany()
                        .HasForeignKey("CariDurumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.CariTipi", "CariTipi")
                        .WithMany()
                        .HasForeignKey("CariTipiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Ilce", "Ilce")
                        .WithMany()
                        .HasForeignKey("IlceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.ParaBirimi", "ParaBirimi")
                        .WithMany()
                        .HasForeignKey("ParaBirimiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Sehir", "Sehir")
                        .WithMany()
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Ulke", "Ulke")
                        .WithMany()
                        .HasForeignKey("UlkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Concrete.Unvan", "Unvan")
                        .WithMany()
                        .HasForeignKey("UnvanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnaSektor");

                    b.Navigation("BagliSektor");

                    b.Navigation("CariDurum");

                    b.Navigation("CariTipi");

                    b.Navigation("Ilce");

                    b.Navigation("ParaBirimi");

                    b.Navigation("Sehir");

                    b.Navigation("Ulke");

                    b.Navigation("Unvan");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Ilce", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Sehir", "Sehir")
                        .WithMany()
                        .HasForeignKey("SehirId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sehir");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Pozisyon", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Departman", "Departman")
                        .WithMany()
                        .HasForeignKey("DepartmanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departman");
                });

            modelBuilder.Entity("EntityLayer.Concrete.Sehir", b =>
                {
                    b.HasOne("EntityLayer.Concrete.Ulke", "Ulke")
                        .WithMany()
                        .HasForeignKey("UlkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ulke");
                });
#pragma warning restore 612, 618
        }
    }
}
