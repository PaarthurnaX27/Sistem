using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class CariTipi:Ortak
	{
		[Key]
		public int CariTipiId { get; set; }

		public string CariTipiAciklama { get; set; }

    }
}

