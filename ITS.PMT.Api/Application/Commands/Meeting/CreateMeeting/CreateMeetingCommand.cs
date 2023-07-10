using ITS.PMT.Domain.Dto.MeetingDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Meeting.CreateMeeting
{
    public class CreateMeetingCommand : IRequest<int>
    {
        public CreateMeetingDto createMeetingDto { get; set; }
    }
}
