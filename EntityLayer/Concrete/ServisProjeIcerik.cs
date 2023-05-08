using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class ServisProjeIcerik:Ortak
	{
        [Key]
        public int ServisProjeIcerikId { get; set; }

        public Proje? Proje { get; set; }

        [ForeignKey("ProjeId")]
        public int ProjeId { get; set; }

        public Modul? Modul { get; set; }

        [ForeignKey("ModulId")]
        public int? ModulId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime GecerlilikTarihBaslangic { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime GecerlilikTarihBitis { get; set; }

        public ParaBirimi? ParaBirimi { get; set; }

        [ForeignKey("ParaBirimiId")]
        public int ParaBirimiId { get; set; }

        public string Fiyat { get; set; }

        public bool  IsEdit { get; set; }
        public int CariId { get; set; }
    }
}

