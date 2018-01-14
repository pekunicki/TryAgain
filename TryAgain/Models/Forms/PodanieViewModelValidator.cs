using FluentValidation;

namespace TryAgain.Models.Forms
{
    public class PodanieViewModelValidator : AbstractValidator<PodanieViewModel>
    {
        public PodanieViewModelValidator()
        {
            RuleFor(reg => reg.StudentOrganizujacyKurs).NotEmpty()
                .WithMessage(EmptyMessage("Student Organizujący Kurs"));

            RuleFor(reg => reg.ProponowanyProwadzacy).NotEmpty()
                .WithMessage(EmptyMessage("Proponowany Prowadzący"));

            RuleFor(reg => reg.Sala).NotEmpty()
                .WithMessage(EmptyMessage("Sala"));

            RuleFor(reg => reg.RodzajKursu).NotEmpty()
                .WithMessage(EmptyMessage("Rodzaj Kursu"));

            RuleFor(reg => reg.Kurs).NotEmpty()
                .WithMessage(EmptyMessage("Kurs"));

            RuleFor(reg => reg.Data).NotEmpty()
                .WithMessage(EmptyMessage("Data"));
        }

        private string EmptyMessage(string fieldName)
        {
            return ValidatorMessages.EmptyValueMessage(fieldName);
        }

    }
}