using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace EntityLayer.Concrete
{
	public class Sehir:Ortak
	{
		[Key]
		public int SehirId { get; set; }

		public string SehirAdi { get; set; }

        public string PlakaKodu { get; set; }

		public string TelefonKodu { get; set; }

		public string  PostaKodu { get; set; }

        public Ulke? Ulke { get; set; }

		[ForeignKey("UlkeId")]
		public int UlkeId { get; set; }

    }
}

