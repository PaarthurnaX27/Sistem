using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Departman:Ortak
	{
		[Key]
		public int DepartmanId { get; set; }

		public string DepartmanAdi { get; set; }
        
    }
}

