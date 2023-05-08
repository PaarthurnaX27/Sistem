using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CalismaDurumu:Ortak
    {
        public int CalismaDurumuId { get; set; }

        public string CalismaDurumuAciklama { get; set; }
    }
}