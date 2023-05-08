using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Unvan:Ortak
	{
		[Key]
		public int UnvanId { get; set; }

		public string UnvanAciklama { get; set; }

		public string UnvanKisaltma { get; set; }

    }
}

