using FluentValidation;
using TryAgain.Services.Interfaces;
using TryAgain.Utils.CustomValidators;
using TryAgain.Utils.ValidatorMessages;

namespace TryAgain.Models.ViewModels
{
    public class ApplicationViewModelValidator : AbstractValidator<ApplicationViewModel>
    {
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        //todo consider dependencies on other rules
        public ApplicationViewModelValidator(
            ICourseService courseService, 
            ITeacherService teacherService)
        {
            _courseService = courseService;
            _teacherService = teacherService;

            RuleFor(reg => reg.OrganizerFullName)
                .NotEmpty()
                .WithName("Student Organizujący Kurs")
                .WithMessage(EmptyValueMessage())
                .DependentRules(rules =>
                {
                    rules.RuleFor(e => e.OrganizerFullName)
                        .MaximumLength(500)
                        .WithMessage(InvalidValueMessage());
                });

            RuleFor(reg => reg.ProposedTeacherFullName)
                .NotEmpty()
                .WithName("Proponowany Prowadzący")
                .WithMessage(EmptyValueMessage())
                .MaximumLength(500)
                .WithMessage(InvalidValueMessage())
                .Must(CheckIfTeacherIsValid)
                .WithMessage(NotExistsInDatabase());

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
                .WithMessage(InvalidValueMessage())
                .Must(CheckIfCourseIsValid)
                .WithMessage(NotExistsInDatabase());
            

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

        private bool CheckIfTeacherIsValid(string teacherFullNme)
        {
            return _teacherService.CheckIfTeacherExists(teacherFullNme);
        }

        private bool CheckIfCourseIsValid(string courseName)
        {
            return _courseService.CheckIfCourseExists(courseName);
        }

        private string EmptyValueMessage(string fieldName = null)
        {
            return ValidatorMessages.EmptyValueMessage(fieldName);
        }

        private string InvalidValueMessage(string fieldName = null)
        {
            return ValidatorMessages.InvalidTimeValueMessage(fieldName);
        }

        private string NotExistsInDatabase(string fieldName = null)
        {
            return ValidatorMessages.NotExistsInDatabase(fieldName);
        }
    }
}