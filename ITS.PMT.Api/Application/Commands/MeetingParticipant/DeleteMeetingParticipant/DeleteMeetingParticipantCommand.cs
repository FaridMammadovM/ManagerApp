using MediatR;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.DeleteMeetingParticipant
{
    public class DeleteMeetingParticipantCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
