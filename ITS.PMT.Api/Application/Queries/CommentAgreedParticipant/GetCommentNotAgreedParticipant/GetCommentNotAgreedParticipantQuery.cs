using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentNotAgreedParticipant
{
    public class GetCommentNotAgreedParticipantQuery : IRequest<List<GetCommentNotAgreedParticipantDto>>
    {
        public int MeetingCommentId { get; set; }
    }
}
