using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ServisDepartman:Ortak
    {
        [Key]
        public int ServisDepartmanId { get; set; }
        public string ServisDepartmanAdi { get; set; }
    }
}