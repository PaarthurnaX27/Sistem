using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Numarator_Tablo
    {
        public int Numarator_TabloId { get; set; }
        public string TabloAdi { get; set; }
        public Numarator? Numarator { get; set; }
        [ForeignKey("NumaratorId")]
        public int NumaratorId { get; set; }
    }
}
