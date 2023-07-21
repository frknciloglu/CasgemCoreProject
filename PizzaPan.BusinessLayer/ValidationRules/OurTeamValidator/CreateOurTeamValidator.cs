using FluentValidation;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaPan.BusinessLayer.ValidationRules.OurTeamValidator
{
    public class CreateOurTeamValidator:AbstractValidator<OurTeam>
    {
        public CreateOurTeamValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("isim Alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim Alanı boş geçilemez");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("lütfen en az 3 karakter giriniz");
            RuleFor(x => x.Title).MaximumLength(30).WithMessage("lütfen en fazla 30 karakter giriniz");

        }
    }
}
