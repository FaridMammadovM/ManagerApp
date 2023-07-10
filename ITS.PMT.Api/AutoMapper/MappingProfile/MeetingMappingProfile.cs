using AutoMapper;
using ITS.PMT.Api.Application.Commands.Meeting.CreateMeeting;
using ITS.PMT.Api.Application.Commands.Meeting.UpdateMeeting;
using ITS.PMT.Domain.Dto.DeleteMeetingDtos;
using ITS.PMT.Domain.Dto.MeetingDtos;
using ITS.PMT.Domain.Models.DeleteMeeting;
using ITS.PMT.Domain.Models.Meeting;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class MeetingMappingProfile : Profile
    {
        public MeetingMappingProfile()
        {
            CreateMap<CreateMeetingCommand, MeetingModel>();
            CreateMap<UpdateMeetingCommand, MeetingModel>();
            CreateMap<MeetingModel, CreateMeetingDto>().ReverseMap();
            CreateMap<MeetingModel, UpdateMeetingDto>().ReverseMap();
            CreateMap<DeleteMeetingDto, DeleteMeetingModel>();
            CreateMap<MeetingModel, GetMeetingByIdDto>();


        }

    }
}
