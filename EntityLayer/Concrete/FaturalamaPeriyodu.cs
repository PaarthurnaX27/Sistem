using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class FaturalamaPeriyodu:Ortak
	{
		[Key]
		public int FaturalamaPeriyoduId { get; set; }
		public string FaturalamaPeriyoduAciklama { get; set; }
		public int PeriyotSayisi { get; set; }
		public int PeriyotNo { get; set; }
	}
}

