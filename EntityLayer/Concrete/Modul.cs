using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Modul : Ortak
    {
        [Key]
        public int ModulId { get; set; }
        public string ModulAdi { get; set; }
        public string ModulKisaltma { get; set; }
        public string ModulNo { get; set; }
    }
}