using AutoMapper;
using Banking_API.Application.Features.Auth.Register.Dtos;
using Banking_API.Domain.Entities.Identity;

namespace Banking_API.Persistence.Profiles.Mapping
{
    public class PersistenceProfile : Profile
    {
        public PersistenceProfile()
        {
            CreateMap<RegisterRequestDto, RegisterResponseDto>().ReverseMap();

        }

    }
}
