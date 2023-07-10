using AutoMapper;
using ITS.PMT.Api.Application.Commands.Team;
using ITS.PMT.Domain.Models.Team;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class TeamMappingProfile : Profile
    {
        public TeamMappingProfile()
        {
            CreateMap<CreateTeamCommand, TeamModel>().ReverseMap();
        }
    }
}
