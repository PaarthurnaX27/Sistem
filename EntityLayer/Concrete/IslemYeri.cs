using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class IslemYeri:Ortak
    {
        [Key]
        public int IslemYeriId { get; set; }
         public string IslemYeriAdi {get; set; }
    }
}