using FluentValidation;
using FluentValidation.Validators;

namespace UserInfo.Application.CustomValidators
{
    public static class MobileNumberValidator
    {
        public static IRuleBuilderOptions<T, string> MatchMobileNumberRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(
                new RegularExpressionValidator<T>(@"^((?:[0-9]\-?){6,14}[0-9])|((?:[0-9]\x20?){6,14}[0-9])$"));
        }
    }
}
