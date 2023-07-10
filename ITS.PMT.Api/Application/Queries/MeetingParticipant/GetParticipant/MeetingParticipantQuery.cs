using ITS.PMT.Domain.Dto.ParticipantDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.MeetingParticipant.GetParticipant
{
    public class MeetingParticipantQuery : IRequest<List<GetParticipantByMeetingIdDto>>
    {
        public int MeetingId { get; set; }

    }
}
