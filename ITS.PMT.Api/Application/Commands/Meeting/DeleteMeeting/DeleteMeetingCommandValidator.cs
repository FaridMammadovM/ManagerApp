using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommandValidator : AbstractValidator<DeleteMeetingCommand>
    {
        public DeleteMeetingCommandValidator()
        {
            RuleFor(x => x.DeleteMeetingDto.MeetingId).NotEqual(0).WithMessage("MeetingId is not null");
            //RuleFor(x => x.DeleteMeetingDto.InsertUser).NotNull().WithMessage("InsertUser is not null");
            //RuleFor(x => x.DeleteMeetingDto.Reason).NotNull().WithMessage("Reason is not null");
        }
    }
}
