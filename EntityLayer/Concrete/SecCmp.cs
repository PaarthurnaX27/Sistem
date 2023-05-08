using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class SecCmp
    {
        [Key]
        public int CompanyId { get; set; }

        public string CompanyNo { get; set; }

        public string CompanyName { get; set; }

        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public bool Status { get; set; }

        public DateTime BeginDate { get; set; }

        public DateTime EndDate { get; set; }

    }
}

