using Banking_API.Application.Features.Auth.Login.Commands;
using Banking_API.Application.Features.Auth.Login.Dtos;
using FluentValidation;

namespace Banking_API.Application.Features.Auth.Login.Validations
{
    public class LoginCommandRequestDtoValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginCommandRequestDtoValidator()
        {
      
         
        }
    }
}
