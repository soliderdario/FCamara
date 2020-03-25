using FluentValidation;
using Super.Digital.Domain.Model;
using System.Text.RegularExpressions;

namespace Super.Digital.Domain.Validations
{
    public class AccountValidation : AbstractValidator<AccountModel>
    {
        public AccountValidation()
        {
            RuleFor(c => ValidateDigit(c.Number)).Equal(true)
                .WithMessage("O campo numéro da conta precisa estar no seguinte formato xxxxx-x.");
        }

        private bool ValidateDigit(string input)
        {
            var result = string.Join("", Regex.Split(input, @"\b\d{5}-\d{1}\b"));
            return result.Length == 0;
        }
    }

}
