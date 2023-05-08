using System;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
	public class CariValidation:AbstractValidator<Cari>
	{
		public CariValidation()
		{
			//RuleFor(x => x.FirmaNo).NotEmpty().WithMessage("Firma No boş geçilmez");
			RuleFor(x => x.Sehir).NotEmpty().WithMessage("Vergi No boş geçilmez");
            //RuleFor(x => x.VergiNo).Equal(11).WithMessage("Lütfen Vergi Numarasını 11 Haneli Girdiğinizden Emin Olunuz");
			//RuleFor(x => x.VergiDairesi).NotEmpty().WithMessage("Vergi Dairesi boş geçilmez");
			//RuleFor(x => x.Sektor).NotEmpty().WithMessage("Sektör boş geçilmez");
	
			//daha sonra buralara gerekli validation kurallarını yaz...


        }
	}
}

