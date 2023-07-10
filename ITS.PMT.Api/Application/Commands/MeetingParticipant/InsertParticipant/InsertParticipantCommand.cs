using MediatR;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.InsertParticipant
{
    public class InsertParticipantCommand : IRequest<int>
    {
        public int? RoleId { get; set; }
        public int? EmployeeId { get; set; }
        public int? MeetingId { get; set; }
    }
}
