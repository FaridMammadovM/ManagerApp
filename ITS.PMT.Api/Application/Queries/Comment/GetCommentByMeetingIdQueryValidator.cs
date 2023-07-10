using FluentValidation;
using ITS.PMT.Api.Application.Queries.MeetingComment;

namespace ITS.PMT.Api.Application.Queries.Comment
{
    public sealed class GetCommentByMeetingIdQueryValidator : AbstractValidator<GetCommentByMeetingIdQuery>
    {
        public GetCommentByMeetingIdQueryValidator()
        {
            RuleFor(t => t.MeetingId).NotEqual(0).WithMessage("MeetingId can't be empty!");
        }
    }
}
