using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class AnaSektor_BagliSektor
    {
        [Key]
        public int Id { get; set; }

        public AnaSektor? AnaSektor { get; set; }

        [ForeignKey("AnaSektorId")]
        public int AnaSektorId { get; set; }

        public BagliSektor? BagliSektor { get; set; }

        [ForeignKey("BagliSektor")]
        public int BagliSektorId { get; set; }
    }
}

