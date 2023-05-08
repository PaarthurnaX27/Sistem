using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class TempFiyatList:Ortak
	{
        [Key]
        public int TempFiyatListId { get; set; }

        public PersonelTipi? PersonelTipi { get; set; }

        [ForeignKey("PersonelTipiId")]
        public int? PersonelTipiId { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? GecerlilikTarihBaslangic { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? GecerlilikTarihBitis { get; set; }

        public ParaBirimi? ParaBirimi { get; set; }

        [ForeignKey("ParaBirimiId")]
        public int? ParaBirimiId { get; set; }

        public string? Fiyat { get; set; }
    }
}

