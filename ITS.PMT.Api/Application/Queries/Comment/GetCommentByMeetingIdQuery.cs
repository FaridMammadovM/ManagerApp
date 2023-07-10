using ITS.PMT.Domain.Dto.CommentDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.MeetingComment
{
    public sealed class GetCommentByMeetingIdQuery : IRequest<List<GetCommentByMeetingIdDto>>
    {
        public int MeetingId { get; set; }
    }
}
