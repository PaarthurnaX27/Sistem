using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class NumaratorDeger
	{
		[Key]
		public int NumaratorDegerId { get; set; }
		public int SimdikiDeger { get; set; }
		public Numarator? Numarator { get; set; }
		[ForeignKey("NumaratorId")]
		public int NumaratorId { get; set; }
	}
}

