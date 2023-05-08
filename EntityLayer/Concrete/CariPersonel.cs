using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CariPersonel : Ortak
    {
        [Key]
        public int CariPersonelId { get; set; }

        public string CariPersonelAdi { get; set; }

        public string? CariPersonelAdi2 { get; set; }

        public string CariPersonelSoyadi { get; set; }

        public string CariPersonelKodu { get; set; }

        public string Telefon { get; set; }

        public string Adres1 { get; set; }

        public string? Adres2 { get; set; }

        public string Mail { get; set; }

        public Unvan? Unvan { get; set; }

        [ForeignKey("UnvanId")]
        public int UnvanId { get; set; }

        public Departman? Departman { get; set; }

        [ForeignKey("DepartmanId")]
        public int DepartmanId { get; set; }

        public Pozisyon? Pozisyon { get; set; }

        [ForeignKey("PozisyonId")]
        public int PozisyonId { get; set; }

        public CalismaDurumu? CalismaDurumu { get; set; }
        [ForeignKey("CalismaDurumuId")]
        public int CalismaDurumuId { get; set; }
        public Cinsiyet? Cinsiyet { get; set; }

        [ForeignKey("CinsiyetId")]
        public int CinsiyetId { get; set; }

        public Cari? Cari { get; set; }

        [ForeignKey("CariId")]
        public int CariId { get; set; }

        public bool SerivsMailGonder { get; set; }

        public bool ServisFaturaGonder { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? IseGirisTarihi { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? IstenCikisTarihi { get; set; }

        public bool? Silinecek { get; set; }

    }
}