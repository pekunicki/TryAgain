using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc.Rendering;
using TryAgain.Models.Constants;

namespace TryAgain.Models.Forms
{
    public class DataToPodanieViewModel
    {
        public DzienTygodnia Dzien { get; set; }
        public RodzajTygodnia Tydzien { get; set; }
        public TimeSpan GodzinaRozpoczecia { get; set; }
        public TimeSpan GodzinaZakoczenia { get; set; }
        public List<SelectListItem> AvailableHours { get; set; }
        public List<SelectListItem> AvailableMinutes { get; set; }

        public DataToPodanieViewModel()
        {
            AvailableHours = GetListOfIntegers(0, 23);
            AvailableMinutes = GetListOfIntegers(0, 59);
        }

        private List<SelectListItem> GetListOfIntegers(int start, int stop)
        {
            return Enumerable.Range(start, stop)
                .Select(c => new SelectListItem { Text = c.ToString(), Value = c.ToString() })
                .ToList();
        }
    }

    public class TimeSpanFormatValidator : PropertyValidator
    {
        public TimeSpanFormatValidator()
            : base(ValidatorMessages.InvalidTimeValueMessage("{PropertyValue}"))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
            {
                return false;
            }
            return TimeSpan.TryParseExact(context.PropertyValue.ToString(), @"hh\:mm", null, out _);
        }
    }

    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, TimeSpan> TimeSpanMustContainHHMMFormat<T>(
            this IRuleBuilder<T, TimeSpan> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new TimeSpanFormatValidator());
        }
    }

    public class DataToPodanieViewModelValidator : AbstractValidator<DataToPodanieViewModel>
    {
        public DataToPodanieViewModelValidator()
        {
            RuleFor(reg => reg.Dzien).NotEmpty()
                .WithMessage(EmptyMessage("Dzień"));

            RuleFor(reg => reg.Tydzien).NotEmpty()
                .WithMessage(EmptyMessage("Tydzień"));

            RuleFor(reg => reg.GodzinaRozpoczecia)
                .NotEmpty()
                .WithMessage(EmptyMessage("Godzina rozpoczęcia"))
                .TimeSpanMustContainHHMMFormat();

            RuleFor(reg => reg.GodzinaZakoczenia).NotEmpty()
                .WithMessage(EmptyMessage("Godzina zakończenia"))
                .TimeSpanMustContainHHMMFormat();
        }

        private string EmptyMessage(string fieldName)
        {
            return ValidatorMessages.EmptyValueMessage(fieldName);
        }
    }
}