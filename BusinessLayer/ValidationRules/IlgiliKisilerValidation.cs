using System;
using EntityLayer.Concrete;
using FluentValidation;
namespace BusinessLayer.ValidationRules
{
    public class IlgiliKisilerValidation:AbstractValidator<IlgiliKisiler>
    {
        public IlgiliKisilerValidation()
        {
            
            //RuleFor(x => x.IlgiliKisiAdi).NotEmpty().WithMessage("İlgili Kişi Adı Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiSoyadi).NotEmpty().WithMessage("İlgili Kişi Soyadı Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiCinsiyet).NotEmpty().WithMessage("İlgili Kisi Cinsiyeti Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiDepartman).NotEmpty().WithMessage("İlgili Kişi Departmanı Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiPozisyon).NotEmpty().WithMessage("İlgili Kişi Pozisyonu Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiKullaniciAdi).NotEmpty().WithMessage("İlgili Kişi Kullanıcı Adı Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiParola).NotEmpty().WithMessage("İlgili Kişi Parolası Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiTelefon).NotEmpty().WithMessage("İlgili Kişi Telefonu Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiDahiliTelefon).NotEmpty().WithMessage("İlgili Kişi Dahili Telefonu Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiDurumu).NotEmpty().WithMessage("İlgili Kişi Durumu Boş Geçilemez");
            //RuleFor(x => x.IlgiliKisiMail).EmailAddress().NotEmpty().WithMessage("İlgili Kişi Maili Boş Geçilemez");

            //daha sonra buralara gerekli validation kurallarını yaz...


        }
    }
}

