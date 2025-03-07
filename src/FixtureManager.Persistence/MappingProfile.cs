using AutoMapper;
using FixtureManager.Domain.Models;
using FixtureManager.Persistence.Tables;

namespace FixtureManager.Persistence;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDetail, DbUserDetails>()
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Credentials.UserName))
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Credentials.PasswordHash))
            .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.ContactInformation.MobileNumber))
            .ForMember(dest => dest.CountryCode, opt => opt.MapFrom(src => src.ContactInformation.CountryCode))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactInformation.Email))
            .ReverseMap();


        CreateMap<School, DbSchool>()
            .ReverseMap();

        CreateMap<Fixture, DbFixture>()
            .ReverseMap();

        CreateMap<Team, DbTeam>()
            .ReverseMap();

        CreateMap<TeamList, DbTeamList>()
            .ReverseMap();
    }
}
