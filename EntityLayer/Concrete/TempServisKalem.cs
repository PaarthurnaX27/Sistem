using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class TempServisKalem 
    {
        [Key]
        public int TempKalemId { get; set; }
        public string GenelAciklama { get; set; }
        Personel? Personel { get; set; }
        [ForeignKey("PersonelId")]
        public int PersonelId { get; set; }
        IslemYeri? IslemYeri { get; set; }
        [ForeignKey("IslemYeriId")]
        public int IslemYeriId { get; set; }
        SonDurum? SonDurum { get; set; }
        [ForeignKey("SonDurumId")]
        public int SonDurumId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BaslamaZamani { get; set; }
    
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BitisZamani { get; set; }
        public string Sure { get; set; }
        public string Aciklama { get; set; }
        public string? ServisKalemNo { get; set; }
        public int SonDegistiren { get; set; }

        public int Olusturan { get; set; }
    }
}