using FluentValidation;
using web.GurselFramework.Entities.Concrete;

namespace web.GurselFramework.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty();
            RuleFor(p => p.Name).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(p => p.Price).GreaterThan(0);
            RuleFor(p => p.Quantity).NotEmpty();
            RuleFor(p => p.Name).Length(2, 20);
            RuleFor(p => p.Price).GreaterThan(20).When(p => p.CategoryId == 1);
            RuleFor(p => p.Url).NotEmpty().WithMessage("Lütfen Url'i boş geçmeyiniz");
        }
    }
}
