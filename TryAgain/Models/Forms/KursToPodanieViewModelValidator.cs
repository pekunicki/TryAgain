using FluentValidation;

namespace TryAgain.Models.Forms
{
    public class KursToPodanieViewModelValidator : AbstractValidator<KursToPodanieViewModel>
    {
        public KursToPodanieViewModelValidator()
        {
            RuleFor(reg => reg.NazwaKursu).NotEmpty()
                .WithMessage(EmptyMessage("Kurs"));

            RuleFor(reg => reg.LiczbaEcts)
                .NotEmpty()
                .WithMessage(EmptyMessage("ECTS"))
                .Must(ects => ects >= 0)
                .WithMessage(ValidatorMessages.InvalidValueMessage("ECTS"));
        }

        private string EmptyMessage(string fieldName)
        {
            return ValidatorMessages.EmptyValueMessage(fieldName);
        }
    }
}