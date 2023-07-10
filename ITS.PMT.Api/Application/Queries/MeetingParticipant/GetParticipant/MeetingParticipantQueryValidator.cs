using FluentValidation;

namespace ITS.PMT.Api.Application.Queries.MeetingParticipant.GetParticipant
{
    public class MeetingParticipantQueryValidator : AbstractValidator<MeetingParticipantQuery>
    {
        public MeetingParticipantQueryValidator()
        {
            RuleFor(t => t.MeetingId).NotEqual(0).WithMessage("MeetingId can't be empty");
        }
    }
}
