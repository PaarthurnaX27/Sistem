using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class FaturaMail:Ortak
	{
        [Key]
        public int FaturaMailId { get; set; }
        public Proje? Proje { get; set; }
        [ForeignKey("ProjeId")]
        public int ProjeId { get; set; }
        public CariPersonel? CariPersonel { get; set; }
        [ForeignKey("CariPersonelId")]
        public int CariPersonelId { get; set; }
        public bool ServisMailiGonderilecekMi { get; set; }
        public bool FaturaMailiGonderilecekMi { get; set; }
    }
}

