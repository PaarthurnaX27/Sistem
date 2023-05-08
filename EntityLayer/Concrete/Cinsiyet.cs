using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Cinsiyet:Ortak
	{
		[Key]
		public int  CinsiyetId { get; set; }

		public string CinsiyetAciklama { get; set; }


    }
}

