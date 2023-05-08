using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class TelefonKodu
	{
		[Key]
		public int id { get; set; }
		public string TelCode1 { get; set; }
		public string TelCode2 { get; set; }
	}
}

