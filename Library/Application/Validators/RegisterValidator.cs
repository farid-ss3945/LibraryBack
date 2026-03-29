// using FluentValidation;
// using Library.Application.DTOs.User;
//
// namespace Library.Application.Validators;
//
// public class RegisterValidator : AbstractValidator<RegisterUserDto>
// {
//     public RegisterValidator()
//     {
//         RuleFor(x => x.FirstName)
//             .NotEmpty().WithMessage("Name is required");
//         RuleFor(x => x.FirstName)
//             .NotEmpty().WithMessage("Last name is required");
//         RuleFor(x => x.Email)
//             .NotEmpty().WithMessage("Email is required")
//             .EmailAddress().WithMessage("Incorrect email");
//         RuleFor(x => x.Password)
//             .NotEmpty().WithMessage("Password is required")
//             .MinimumLength(8).WithMessage("Password should have at least 8 symbols")
//             .Password();
//         RuleFor(x => x.ConfirmPassword)
//             .NotEmpty().WithMessage("Password is required")
//             .MinimumLength(8).WithMessage("Password should have at least 8 symbols")
//             .Password()
//             .Equal(x => x.Password).WithMessage("Passwords do not match");
//     }
// }