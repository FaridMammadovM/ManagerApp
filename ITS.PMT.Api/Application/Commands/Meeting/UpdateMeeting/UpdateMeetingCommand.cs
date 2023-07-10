using ITS.PMT.Domain.Dto.MeetingDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Meeting.UpdateMeeting
{
    public class UpdateMeetingCommand : IRequest<int>
    {
        public UpdateMeetingDto updateMeetingDto { get; set; }
    }
}
