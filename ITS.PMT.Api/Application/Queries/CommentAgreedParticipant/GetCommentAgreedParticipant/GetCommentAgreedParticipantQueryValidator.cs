using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.MeetingCommentAgreedParticipant.MeetingCommentAgreedParticipant
{
    public sealed class GetCommentAgreedParticipantQueryValidator : AbstractValidator<GetCommentAgreedParticipantQuery>
    {

        public GetCommentAgreedParticipantQueryValidator()
        {
            RuleFor(t => t.MeetingCommentId).NotEqual(0).WithMessage("MeetingCommentId can't be empty");
        }

    }
}
