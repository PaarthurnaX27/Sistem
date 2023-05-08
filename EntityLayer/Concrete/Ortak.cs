using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Ortak
    {
         public bool Silindi { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SonDegistirmeTarih { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime OlusturulmaTarih { get; set; }

        public int SonDegistiren { get; set; }

        public int Olusturan { get; set; }
    }
}