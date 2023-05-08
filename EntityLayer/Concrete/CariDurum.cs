using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class CariDurum:Ortak
	{
		[Key]
		public int CariDurumId { get; set; }

		public string CariDurumAciklama { get; set; }

    }
}

