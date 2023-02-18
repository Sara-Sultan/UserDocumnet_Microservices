using FluentValidation;
using FluentValidation.Validators;

namespace UserInfo.Application.CustomValidators
{
    public static class NameArEnValidator
    {
        public static IRuleBuilderOptions<T, string> MatchNameArEnValidatorRule<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(
                new RegularExpressionValidator<T>(@"^[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z]+[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa-zA-Z-_]*$"));
        }
    }
}
