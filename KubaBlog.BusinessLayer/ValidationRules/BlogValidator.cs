using FluentValidation;
using KubaBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubaBlog.BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Lütfen blog başlığını boş bırakmayınız.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Lütfen blog içeriğini boş bırakmayınız.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Lütfen blog dosya yolunu boş bırakmayınız.");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karakterden daha az veri girişi yapınız.");
            RuleFor(x => x.BlogContent).MinimumLength(5).WithMessage("Lütfen 4 karakterden daha fazla veri girişi yapınız.");
        }
    }
}
