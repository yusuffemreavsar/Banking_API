using Banking_API.Application.Features.Auth.Register.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_API.Application.Features.Auth.Register.Validations
{
    public class RegisterCommandRequestDtoValidator: AbstractValidator<RegisterCommandRequest>
    {
        public RegisterCommandRequestDtoValidator()
        {
            RuleFor(x => x._RegisterRequestDto.FirstName)
           .NotEmpty().WithMessage("First name is required.")
           .MinimumLength(2).WithMessage("First name must be at least 2 characters long.")
           .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

            RuleFor(x => x._RegisterRequestDto.LastName)
                .NotEmpty().WithMessage("Last name is required.")
                .MinimumLength(2).WithMessage("Last name must be at least 2 characters long.")
                .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

            RuleFor(x => x._RegisterRequestDto.UserName)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.")
                .MaximumLength(20).WithMessage("Username must not exceed 20 characters.");

            RuleFor(x => x._RegisterRequestDto.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Enter a valid email address.")
                .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

            RuleFor(x => x._RegisterRequestDto.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Enter a valid phone number.");

            RuleFor(x => x._RegisterRequestDto.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
        }

    }
}
