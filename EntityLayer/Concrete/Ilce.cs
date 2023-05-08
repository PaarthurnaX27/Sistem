using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class Ilce:Ortak
	{
		[Key]
		public int IlceId { get; set; }

		public Sehir? Sehir { get; set; }

		[ForeignKey("SehirId")]
		public int SehirId { get; set; }

		public string IlceAdi { get; set; }

		public string? PostaKodu { get; set; }

    }
}

