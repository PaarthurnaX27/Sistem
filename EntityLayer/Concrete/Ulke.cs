using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Ulke:Ortak
	{
		[Key]
		public int UlkeId { get; set; }

		public string UlkeAdi { get; set; }

		public string BinaryCode { get; set; }

		public string TripleCode { get; set; }

		public string TelefonKodu { get; set; }

    }
}

