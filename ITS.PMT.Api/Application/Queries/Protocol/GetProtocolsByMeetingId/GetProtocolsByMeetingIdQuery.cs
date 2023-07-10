using ITS.PMT.Domain.Dto.ProtocolDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Protocol.GetProtocolsByMeetingId
{
    public class GetProtocolsByMeetingIdQuery : IRequest<List<GetProtocolsByMeetingIdDto>>
    {
        public int MeetingId { get; set; }
    }
}
