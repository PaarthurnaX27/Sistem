using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Sube
	{
		[Key]
		public int SubeId { get; set; }

		public string Telefon { get; set; }

		public string Telefon2 { get; set; }

		public string Mail { get; set; }

		public string WebSite { get; set; }

		public string Adres { get; set; }

        public string Ulke { get; set; }

        public string Sehir { get; set; }

		
	}
}

