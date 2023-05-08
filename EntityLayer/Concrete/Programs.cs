using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Programs:Ortak
	{
		[Key]
		public int  ProgramId { get; set; }
		public string ProgramAdi { get; set; }
	}
}

