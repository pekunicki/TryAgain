using System;
using System.Globalization;
using FluentValidation.Validators;
using TryAgain.Utils.Extensions;

namespace TryAgain.Utils.CustomValidators
{
    public class TimeSpanFormatValidator : PropertyValidator
    {
        public TimeSpanFormatValidator()
            : base(ValidatorMessages.ValidatorMessages.InvalidTimeValueMessage("{PropertyValue}"))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return context.PropertyValue?.ToString().TryParseToTimeSpan() != null;
        }
    }
}