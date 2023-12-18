using AutoMapper;
using CzlonkowieZespoluBackend.Application.Dtos;
using CzlonkowieZespoluBackend.Domain.Entities;

namespace CzlonkowieZespoluBackend.Application.Mappings
{
    public class TeamMemberMappingProfile : Profile
    {
        public TeamMemberMappingProfile() 
        {
            CreateMap<TeamMember, TeamMemberDto>();
            CreateMap<TeamMemberDto, TeamMember>();
            CreateMap<TeamMember, RandomTeamMemberDto>();
            CreateMap<RandomTeamMemberDto, TeamMember>();
            CreateMap<TeamMember, AddTeamMemberDto>();
            CreateMap<AddTeamMemberDto, TeamMember>();
        }
    }
}