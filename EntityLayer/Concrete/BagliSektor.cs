using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class BagliSektor:Ortak
	{
		[Key]
		public int BagliSektorId { get; set; }

		public string BagliSektorAdi { get; set; }

 

        public AnaSektor? AnaSektor { get; set; }

        [ForeignKey("AnaSektorId")]
        public int AnaSektorId { get; set; }
    }
}

