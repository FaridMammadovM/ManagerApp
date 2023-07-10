using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.InsertParticipant
{
    public class InsertParticipantValidator : AbstractValidator<InsertParticipantCommand>
    {
        public InsertParticipantValidator()
        {
            RuleFor(t => t.EmployeeId).NotEqual(0).WithMessage("Id cannot be null");
            RuleFor(t => t.RoleId).NotEqual(0).WithMessage("Id cannot be null");
            RuleFor(t => t.MeetingId).NotEqual(0).WithMessage("Id cannot be null");
        }
    }
}
