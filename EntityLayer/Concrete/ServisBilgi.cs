using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServisBilgi:Ortak
    {
        [Key]
        public int ServisId { get; set; }
        public string ServisNo { get; set; }
        public Cari? Cari { get; set; }

        [ForeignKey("CariId")]
        public int CariId { get; set; }
        public ServisDepartman? ServisDepartman { get; set; }

        [ForeignKey("ServisDepartmanId")]
        public int ServisDepartmanId { get; set; }
        public Modul? Modul { get; set; }

        [ForeignKey("ModulId")]
        public int ModulId { get; set; }
        public string DepartmanYetkilisi { get; set; }
        public string Konu { get; set; }
        public int ServisSekliId { get; set; }
        public Oncelik? Oncelik { get; set; }
        [ForeignKey("OncelikId")]
        public int OncelikId { get; set; }
        public ServisTipi? ServisTipi { get; set; }

        [ForeignKey("ServisTipiId")]
        public int ServisTipiId { get; set; }
        public Personel? Personel { get; set; }

        [ForeignKey("PersonelId")]
        public int PersonelId { get; set; }
        public string? TSuresi { get; set; }
        public string? FTSuresi { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime TarihSaat { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime PlanlananTarih { get; set; }

        public string TahminiSure { get; set; }

        public string GercekSure { get; set; }
        public string GirilenSure { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime SonDurumTarihi { get; set; }

        public SonDurum? SonDurum { get; set; }
        [ForeignKey("SonDurumId")]
        public int SonDurumID { get; set; }
        public string Ay { get; set; }
        public string Yil { get; set; }
        public bool Kapandi { get; set; }
        public bool MusteriOnayi { get; set; }

    }
}