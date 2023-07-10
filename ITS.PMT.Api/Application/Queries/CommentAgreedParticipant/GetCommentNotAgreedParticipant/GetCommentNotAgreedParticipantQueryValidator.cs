using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentNotAgreedParticipant
{
    public sealed class GetMeetingCommentNotAgreedParticipantQueryValidator : AbstractValidator<GetCommentNotAgreedParticipantQuery>
    {

        public GetMeetingCommentNotAgreedParticipantQueryValidator()
        {
            RuleFor(t => t.MeetingCommentId).NotEqual(0).WithMessage("MeetingCommentId can't be empty");
        }


    }
}
