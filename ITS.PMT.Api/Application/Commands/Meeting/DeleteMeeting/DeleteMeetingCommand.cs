using ITS.PMT.Domain.Dto.DeleteMeetingDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommand : IRequest<int>
    {
        public DeleteMeetingDto DeleteMeetingDto { get; set; }
    }
}
