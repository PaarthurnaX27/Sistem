using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Oncelik:Ortak
    {
        [Key]
        public int OncelikId { get; set; }
        public string OncelikAciklama { get; set; }
    }
}