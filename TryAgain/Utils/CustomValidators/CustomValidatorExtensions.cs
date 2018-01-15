using FluentValidation;

namespace TryAgain.Utils.CustomValidators
{
    public static class CustomValidatorExtensions
    {
        public static IRuleBuilderOptions<T, string> TimeSpanMustContainHHMMFormat<T>(
            this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new TimeSpanFormatValidator());
        }
    }
}