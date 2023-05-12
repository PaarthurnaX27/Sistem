using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
	public class Numarator
	{
		[Key]
		public int NumaratorId { get; set; }
		public string NumaratorAciklama { get; set; }
		public int ParcaUzunlugu { get; set; }
		public int? Sira1 { get; set; }
		public int? Sira2 { get; set; }
		public int? Sira3 { get; set; }
        public int? Sira4 { get; set; }
        public int? Sira5 { get; set; }
        public int? Sira6 { get; set; }
		public string? Karakter1 { get; set; }
        public string? Karakter2 { get; set; }
        public string? Karakter3 { get; set; }
        public string? Karakter4 { get; set; }
        public string? Karakter5 { get; set; }
        public int? Numara { get; set; }
		public string? Parametre1 { get; set; }
		public string? Parametre2 { get; set; }
		public string?  OnEk { get; set; }
		public int BaslangicSayisi { get; set; }
		public int ArttirmaAraligi { get; set; }
		public string? DoldurmaKarakteri { get; set; }
		public string? SonEk { get; set; }
	}
}

