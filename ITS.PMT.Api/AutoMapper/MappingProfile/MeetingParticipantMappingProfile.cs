using AutoMapper;
using ITS.PMT.Api.Application.Commands.MeetingParticipant.InsertParticipant;
using ITS.PMT.Domain.Dto.ParticipantDtos;
using ITS.PMT.Domain.Models.MeetingParticipant;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class MeetingParticipantMappingProfile : Profile
    {
        public MeetingParticipantMappingProfile()
        {
            CreateMap<InsertParticipantCommand, MeetingParticipantModel>().ReverseMap();
            CreateMap<MeetingParticipantModel, GetParticipantByMeetingIdDto>();


        }
    }
}
