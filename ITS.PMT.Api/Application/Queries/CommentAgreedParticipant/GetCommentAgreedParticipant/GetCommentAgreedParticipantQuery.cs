using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentAgreedParticipant
{
    public class GetCommentAgreedParticipantQuery : IRequest<List<GetCommentAgreedParticipantDto>>
    {
        public int MeetingCommentId { get; set; }

    }
}
