using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Modul_ServisDepartman
    {
        [Key]
        public int Modul_ServisDepartmanId { get; set; }
        public Modul? Modul { get; set; }

        [ForeignKey("ModulId")]
        public int ModulId { get; set; }

        [ForeignKey("ServisDepartmanId")]
        public int ServisDepartmanId { get; set; }

    }
}