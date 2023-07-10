using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Meeting.CreateMeeting
{
    public class CreateMeetingCommandValidator : AbstractValidator<CreateMeetingCommand>
    {
        public CreateMeetingCommandValidator()
        {
            //RuleFor(x=>x.createMeetingDto.InsertUser).NotEmpty().WithMessage("Insert user name can not empty");
        }
    }
}
