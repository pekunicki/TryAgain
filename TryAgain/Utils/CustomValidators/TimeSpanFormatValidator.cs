using System;
using System.Globalization;
using FluentValidation.Validators;
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
            if (context.PropertyValue == null)
            {
                return false;
            }
            var formats = new[] {@"hh\:mm", @"hh\:mm\:ss"};

            if (TimeSpan.TryParseExact(context.PropertyValue.ToString(), formats, CultureInfo.InvariantCulture, out var value))
            {
                if (value.Hours >= 0 
                    && value.Minutes >= 0
                    && value.Days == 0
                    && value.Seconds == 0
                    && value.Milliseconds == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}