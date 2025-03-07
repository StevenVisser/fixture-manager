using AutoMapper;
using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Dtos;

namespace FixtureManager.Domain;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<UserDetail, UserDto>();
    }
}
