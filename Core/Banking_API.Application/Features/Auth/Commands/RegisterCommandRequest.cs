using Banking_API.Application.Features.Auth.Dtos;
using MediatR;

namespace Banking_API.Application.Features.Auth.Commands
{
    public class RegisterCommandRequest:IRequest<RegisterCommandResponse>
    {
        public RegisterRequestDto _RegisterRequestDto { get; set; }

    }
}
