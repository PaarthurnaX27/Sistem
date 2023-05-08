using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Kullanici
    {
        [Key]
        public int KullaniciId { get; set; }

        public string KullaniciAdi { get; set; }

        public string? KullaniciAdi2 { get; set; }

        public string KullaniciSoyadi { get; set; }

        public string? PersonelKullaniciAdi { get; set; }

        public string KullaniciMail { get; set; }

        public string KullaniciParola { get; set; }

        public string KullaniciKodu { get; set; }


    }
}

