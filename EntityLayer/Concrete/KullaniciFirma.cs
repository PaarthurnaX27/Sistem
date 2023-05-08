using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
	public class KullaniciFirma
	{
		[Key]
		public int Id { get; set; }

		public virtual Kullanici? Kullanici { get; set; }

		[ForeignKey("KullaniciId")]
		public int KullaniciId { get; set; }

		public virtual SecCmp? SecCmp { get; set; }

		[ForeignKey("CompanyId")]
		public int CompanyId { get; set; }
	}
}
