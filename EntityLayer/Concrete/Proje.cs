using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class Proje:Ortak
	{
		[Key]
		public int ProjeId { get; set; }

		public Cari? Cari { get; set; }

		[ForeignKey("CariId")]
		public int CariId { get; set; }

		public string ProjeNo { get; set; }

		public Programs? Programs { get; set; }

		[ForeignKey("ProgramId")]
		public int ProgramId { get; set; }

		public FaturalamaPeriyodu? FaturalamaPeriyodu { get; set; }

		[ForeignKey("FaturalamaPeriyoduId")]
		public int FaturalamaPeriyoduId { get; set; }

		public bool ServisProjesi { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProjeBaslangicTarihi { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ProjeBitisTarihi { get; set; }
	}
}

