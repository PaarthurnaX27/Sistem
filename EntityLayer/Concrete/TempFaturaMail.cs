using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class TempFaturaMail:Ortak
	{
		[Key]
		public int TempFaturaMailId { get; set; }
		public CariPersonel? CariPersonel { get; set; }
		[ForeignKey("CariPersonelId")]
		public int CariPersonelId { get; set; }
		public bool ServisMailiGonderilecekMi { get; set; }
		public bool FaturaMailiGonderilecekMi { get; set; }
	}
}

