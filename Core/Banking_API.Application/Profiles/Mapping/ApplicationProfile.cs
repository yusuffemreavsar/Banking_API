using AutoMapper;
using Banking_API.Application.Features.Auth.Dtos;
using Banking_API.Domain.Entities.Identity;


namespace Banking_API.Application.Profiles.Mapping
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            CreateMap<RegisterRequestDto, AppUser>().ReverseMap();
        }
    }
}
