using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SonDurum:Ortak
    {
        [Key]
        public int SonDurumId { get; set; }
        public string SonDurumAciklama { get; set; }
    }
}