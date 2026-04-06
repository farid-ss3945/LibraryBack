using System.Text.RegularExpressions;
using FluentValidation;

namespace Library.Application.Validators;

public static class PasswordExtension
{
    public static IRuleBuilder<T, string> Password<T>(
        this IRuleBuilder<T, string> ruleBuilder,
        bool mustContainLowerCase = true,
        bool mustContainUpperCase = true,
        bool mustContainDigit = true)
    {
        return ruleBuilder
            .Must(password =>
            {
                if (mustContainLowerCase && !Regex.IsMatch(password, @"[a-z]")) return false;
                if (mustContainUpperCase && !Regex.IsMatch(password, @"[A-Z]")) return false;
                if (mustContainDigit && !Regex.IsMatch(password, @"\d")) return false;
                return true;
            })
            .WithMessage("Password must contain at least one lowercase letter, one uppercase letter, and one digit.");
    }
}