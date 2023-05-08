using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class AnaSektor:Ortak
	{
		[Key]
		public int  AnaSektorId { get; set; }

		public string AnaSektorAdi { get; set; }

       
    }
}

