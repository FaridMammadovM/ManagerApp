using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.SendMailParticipant
{
    public class SendMailParticipantValidator : AbstractValidator<SendMailParticipantCommand>
    {
        public SendMailParticipantValidator()
        {
            RuleFor(c => c.MeetingId).NotEqual(0).WithMessage("MeetingId can't be empty");
            RuleFor(c => c.Flag).NotEqual(0).WithMessage("Flag can't be empty");
        }
    }
}
