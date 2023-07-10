using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Meeting.UpdateMeeting
{
    public class UpdateMeetingCommandValidator : AbstractValidator<UpdateMeetingCommand>
    {
        public UpdateMeetingCommandValidator()
        {
            RuleFor(x => x.updateMeetingDto.Id).NotEmpty().WithMessage("Id not empty");
            //RuleFor(x => x.updateMeetingDto.UpdateUser).NotEmpty().WithMessage("Update user name can not empty");
        }
    }
}
