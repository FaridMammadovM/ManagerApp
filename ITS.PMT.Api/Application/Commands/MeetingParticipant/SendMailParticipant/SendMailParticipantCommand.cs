using MediatR;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.SendMailParticipant
{
    public class SendMailParticipantCommand : IRequest<int>
    {
        public int MeetingId { get; set; }
        public int Flag { get; set; }
    }
}
