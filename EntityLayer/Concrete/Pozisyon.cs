using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class Pozisyon:Ortak
	{
		[Key]
		public int PozisyonId { get; set; }

		public string PozisyonAdi { get; set; }

		public Departman? Departman { get; set; }

        [ForeignKey("DepartmanId")]
		public int DepartmanId { get; set; }


    }
}

