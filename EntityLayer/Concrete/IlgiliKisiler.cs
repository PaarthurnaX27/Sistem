using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class IlgiliKisiler:Ortak
	{
		[Key]
		public int IlgiliKisiId { get; set; }

		[ForeignKey("CariId")]
		public int CariId { get; set; }

		[ForeignKey("PersonelId")]
		public int PersonelId { get; set; }


    }
}

