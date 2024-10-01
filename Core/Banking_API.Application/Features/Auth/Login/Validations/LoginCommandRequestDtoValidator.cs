using Banking_API.Application.Features.Auth.Login.Commands;
using FluentValidation;

namespace Banking_API.Application.Features.Auth.Login.Validations
{
    public class LoginCommandRequestDtoValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandRequestDtoValidator()
        {

            RuleFor(x => x.LoginRequestDto.Email)
               .NotEmpty().WithMessage("Email field cannot be empty.")
               .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.LoginRequestDto.Password)
               .NotEmpty().WithMessage("Password field cannot be empty.")
               .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
               .MaximumLength(20).WithMessage("Password cannot exceed 20 characters.");
        }
    }
}
