using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class PersonelTipi:Ortak
	{
		[Key]
		public int PersonelTipiId { get; set; }
		public string  PersonelTipiAciklama { get; set; }
	}
}

