using System;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concrete
{
	public class SmServisContext:DbContext
	{
        public static string data;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseNpgsql("User Id=postgres;Password=4909;Host=localhost;Port=5432;Database=" + "SmServisDb2" + ";");
		}
		public DbSet<Cari> Caris { get; set; }
		public DbSet<Sube> Subes { get; set; }
		public DbSet<IlgiliKisiler> IlgiliKisilers { get; set; }
		public DbSet<Ulke> Ulkes { get; set; }
		public DbSet<Sehir> Sehirs { get; set; }
		public DbSet<Ilce> Ilces { get; set; }
		public DbSet<CariDurum> CariDurums { get; set; }
		public DbSet<ParaBirimi> ParaBirimis { get; set; }
		public DbSet<AnaSektor> AnaSektors { get; set; }
		public DbSet<BagliSektor> BagliSektors { get; set; }
		public DbSet<AnaSektor_BagliSektor> AnaSektor_BagliSektors { get; set; }
		public DbSet<Cinsiyet> Cinsiyets { get; set; }
		public DbSet<Unvan> Unvans { get; set; }
		public DbSet<Pozisyon> Pozisyons { get; set; }
		public DbSet<Departman> Departmans { get; set; }
		public DbSet<CariTipi> CariTipis { get; set; }
		public DbSet<Personel> Personels { get; set; }
		public DbSet<CariPersonel> CariPersonels { get; set; }
		public DbSet<CalismaDurumu> CalismaDurumus { get; set; }		
		public DbSet<TempCariPersonel> TempCariPersonels { get; set; }
		public DbSet<TempCari> TempCaris { get; set; }
		public DbSet<Modul> Moduls { get; set; }
		public DbSet<ServisDepartman> ServisDepartmans { get; set; }
		public DbSet<Modul_ServisDepartman> Modul_ServisDepartmans { get; set; }
		public DbSet<SonDurum> SonDurums { get; set; }
		public DbSet<ServisTipi> ServisTipis { get; set; }
		public DbSet<ServisSekli> ServisSeklis { get; set; }
		public DbSet<IslemYeri> IslemYeris { get; set; }
		public DbSet<Oncelik> Onceliks { get; set; }
		public DbSet<ServisKalem> ServisKalems { get; set; }
		public DbSet<ServisBilgi> ServisBilgis { get; set; }
		public DbSet<TempServisKalem> TempServisKalems { get; set; }
		public DbSet<TempServisBilgi> TempServisBilgis { get; set; }
		public DbSet<PersonelTipi> PersonelTipis { get; set; }
		public DbSet<FaturalamaPeriyodu> FaturalamaPeriyodus { get; set; }
		public DbSet<Proje> Projes { get; set; }
		public DbSet<ProjeIcerik> ProjeIceriks { get; set; }
		public DbSet<TempDanisman> TempDanismans { get; set; }
		public DbSet<TempFiyatList> TempFiyatLists { get; set; }
		public DbSet<ServisProjeIcerik> ServisProjeIceriks { get; set; }
		public DbSet<TempServisProjeIcerik> TempServisProjeIceriks { get; set; }
		public DbSet<Programs> Programs { get; set; }
		public DbSet<TempCariProgram> TempCariPrograms { get; set; }
		public DbSet<TempFaturaMail> TempFaturaMails { get; set; }
		public DbSet<FaturaMail> FaturaMails { get; set; }
	}
}

