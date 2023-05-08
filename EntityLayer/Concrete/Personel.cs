using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class Personel:Ortak
	{
		[Key]
		public int PersonelId { get; set; }

		public string PersonelAdi { get; set; }

		public string? PersonelAdi2 { get; set; }

		public string PersonelSoyadi { get; set; }

		public string PersonelKodu { get; set; }

		public string? PersonelKullaniciAdi { get; set; }

		public string Telefon { get; set; }

		public string Adres1 { get; set; }

		public string? Adres2 { get; set; }

		public string Mail { get; set; }

		public string Parola { get; set; }

		public Cinsiyet? Cinsiyet { get; set; }

		[ForeignKey("CinsiyetId")]
		public int CinsiyetId { get; set; }

		public Unvan? Unvan { get; set; }
		
		[ForeignKey("UnvanId")]
		public int UnvanId { get; set; }

		public Departman? Departman { get; set; }

		[ForeignKey("DepartmanId")]

		public int DepartmanId { get; set; }

		public Pozisyon? Pozisyon { get; set; }

		[ForeignKey("PosisyonId")]

		public int PozisyonId { get; set; }

		public bool CalismaDurumu { get; set; }



	}
}
