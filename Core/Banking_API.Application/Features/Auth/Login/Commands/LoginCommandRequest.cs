using Banking_API.Application.Features.Auth.Login.Dtos;
using MediatR;

namespace Banking_API.Application.Features.Auth.Login.Commands
{
    public class LoginCommandRequest:IRequest<LoginCommandResponse>
    {
        public LoginRequestDto LoginRequestDto { get; set; }
    }
}
