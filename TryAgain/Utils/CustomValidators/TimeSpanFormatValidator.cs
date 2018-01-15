using System;
using System.Globalization;
using FluentValidation.Validators;
using TryAgain.Utils.Extensions;
using TryAgain.Utils.ValidatiorMessages;

namespace TryAgain.Utils.CustomValidators
{
    public class TimeSpanFormatValidator : PropertyValidator
    {
        public TimeSpanFormatValidator()
            : base(ValidatorMessages.InvalidTimeValueMessage("{PropertyValue}"))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return context.PropertyValue?.ToString().TryParseToTimeSpan() != null;
        }
    }
}