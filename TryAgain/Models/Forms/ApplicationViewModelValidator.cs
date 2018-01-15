using FluentValidation;
using TryAgain.Utils.CustomValidators;
using TryAgain.Utils.ValidatiorMessages;

namespace TryAgain.Models.Forms
{
    public class ApplicationViewModelValidator : AbstractValidator<ApplicationViewModel>
    {
        public ApplicationViewModelValidator()
        {
            RuleFor(reg => reg.Organizer)
                .NotEmpty()
                .WithName("Student Organizujący Kurs")
                .WithMessage(EmptyValueMessage())
                .MaximumLength(500)
                .WithMessage(InvalidValueMessage());

            RuleFor(reg => reg.ProposedTeacher)
                .NotEmpty()
                .WithName("Proponowany Prowadzący")
                .WithMessage(EmptyValueMessage())
                .MaximumLength(500)
                .WithMessage(InvalidValueMessage());

            RuleFor(reg => reg.Classroom)
                .NotEmpty()
                .WithName("Sala")
                .WithMessage(EmptyValueMessage())
                .MaximumLength(500)
                .WithMessage(InvalidValueMessage());

            RuleFor(reg => reg.Type)
                .IsInEnum()
                .NotEmpty()
                .WithName("Rodzaj Kursu")
                .WithMessage(EmptyValueMessage());

            RuleFor(reg => reg.Course.Ects)
                .NotEmpty()
                .WithName("ECTS")
                .WithMessage(EmptyValueMessage())
                .Must(ects => ects >= 0 && ects <= 1000)
                .WithMessage(InvalidValueMessage());

            RuleFor(reg => reg.Course.CourseName)
                .NotEmpty()
                .WithName("Kurs")
                .WithMessage(EmptyValueMessage())
                .MaximumLength(500)
                .WithMessage(InvalidValueMessage());

            RuleFor(reg => reg.Date.Day)
                .IsInEnum()
                .WithName("Dzień")
                .WithMessage(EmptyValueMessage());

            RuleFor(reg => reg.Date.Week)
                .IsInEnum()
                .WithName("Tydzień")
                .WithMessage(EmptyValueMessage());

            //todo consider adding a requirements for comparing start to end time
            RuleFor(reg => reg.Date.StartTime)
                .NotEmpty()
                .WithName("Godzina rozpoczęcia")
                .WithMessage(EmptyValueMessage())
                .TimeSpanMustContainHHMMFormat();

            RuleFor(reg => reg.Date.EndTime)
                .NotEmpty()
                .WithName("Godzina zakończenia")
                .WithMessage(EmptyValueMessage())
                .TimeSpanMustContainHHMMFormat();
        }

        private string EmptyValueMessage(string fieldName = null)
        {
            return ValidatorMessages.EmptyValueMessage(fieldName);
        }

        private string InvalidValueMessage(string fieldName = null)
        {
            return ValidatorMessages.InvalidTimeValueMessage(fieldName);
        }

    }
}