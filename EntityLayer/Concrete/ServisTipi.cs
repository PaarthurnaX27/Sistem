using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServisTipi:Ortak
    {
        [Key]
        public int ServisTipiId { get; set; }
        public string ServisTipiAciklama { get; set; }
    }
}