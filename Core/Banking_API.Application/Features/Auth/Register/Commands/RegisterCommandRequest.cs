using Banking_API.Application.Features.Auth.Register.Dtos;
using MediatR;

namespace Banking_API.Application.Features.Auth.Register.Commands
{
    public class RegisterCommandRequest : IRequest<RegisterCommandResponse>
    {
        public RegisterRequestDto _RegisterRequestDto { get; set; }

    }
}
