
using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class ParaBirimi:Ortak
	{
		[Key]
		public int ParaBirimiId { get; set; }

		public string ParaBirimiAdi { get; set; }

		public string ParaBirimiKisaltma { get; set; }

		public string? ParaBirimiSimge { get; set; }

    }
}

