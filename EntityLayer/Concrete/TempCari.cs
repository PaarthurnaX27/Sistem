using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TempCari:Ortak
    {
         [Key]
        public int CariId { get; set; }

        public int FirmaNo { get; set; }

        public string CariAdi { get; set; }

        public CariTipi? CariTipi { get; set; }

        [ForeignKey("CariTipiId")]
        public int CariTipiId { get; set; }

        public string HesapKodu { get; set; }

        public string VergiDairesi { get; set; } 

        public string VergiNo { get; set; }

        public string CariDil { get; set; }

        public Ulke? Ulke { get; set; }

        [ForeignKey("UlkeId")]
        public int UlkeId { get; set; }

        public Sehir? Sehir { get; set; }

        [ForeignKey("SehirId")]
        public int SehirId { get; set; }

        public Ilce? Ilce { get; set; }

        [ForeignKey("IlceId")]
        public int IlceId { get; set; }

        public CariDurum? CariDurum { get; set; }

        [ForeignKey("CariDurumId")]
        public int CariDurumId { get; set; }

        public ParaBirimi? ParaBirimi { get; set; }

        [ForeignKey("ParaBirimiId")]
        public int ParaBirimiId { get; set; }

        public string  WebSitesi { get; set; }

        public string Telefon1 { get; set; }

        public string Telefon2 { get; set; }

        public string Adres { get; set; }

        public string MailAdresi1 { get; set; }

        public string MailAdresi2 { get; set; }

        public AnaSektor? AnaSektor { get; set; }

        [ForeignKey("AnaSektorId")]
        public int AnaSektorId { get; set; }

        public BagliSektor? BagliSektor { get; set; }

        [ForeignKey("BagliSektorId")]
        public int? BagliSektorId { get; set; }

        public bool eFaturaMukellefi { get; set; }

        public bool eIrsaliyeMukellefi { get; set; }
    }
}