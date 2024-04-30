using FluentValidation;
using KubaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.BusinessLayer.ValidationRules
{
	public class WriterValidator : AbstractValidator<Writer>
	{
		public WriterValidator()
		{
			RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez.");
			RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Email adresi bol geçilemez.");
			RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola boş geçilemez.");
			RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karater girişi yapınız.");
			RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karaterlik veri girişi yapınız.");

		}
	}
}
