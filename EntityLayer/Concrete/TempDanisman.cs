using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class TempDanisman:Ortak
	{
		[Key]
		public int TempDanismanId { get; set; }

		public Personel? Personel { get; set; }

		[ForeignKey("PersonelId")]
		public int PersonelId { get; set; }

		public PersonelTipi? PersonelTipi { get; set; }

		[ForeignKey("PersonelTipiId")]
		public int PersonelTipiId { get; set; }
	}
}

