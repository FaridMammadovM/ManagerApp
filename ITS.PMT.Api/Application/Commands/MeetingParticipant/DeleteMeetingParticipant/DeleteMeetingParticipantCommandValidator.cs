using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.DeleteMeetingParticipant
{
    public class DeleteMeetingParticipantCommandValidator : AbstractValidator<DeleteMeetingParticipantCommand>
    {
        public DeleteMeetingParticipantCommandValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).WithMessage("Id is not empty");
        }
    }
}
