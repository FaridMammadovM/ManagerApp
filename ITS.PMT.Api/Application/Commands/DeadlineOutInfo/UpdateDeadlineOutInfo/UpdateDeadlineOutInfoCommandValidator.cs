using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.DeadlineOutInfo.UpdateDeadlineOutInfo
{
    public class UpdateDeadlineOutInfoCommandValidator : AbstractValidator<UpdateDeadlineOutInfoCommand>
    {

        public UpdateDeadlineOutInfoCommandValidator()
        {
            //RuleFor(x => x.updateDeadlineOutInfoDto.ExtraDay).NotEmpty().WithMessage("Extra day can not be null");
            //RuleFor(x => x.updateDeadlineOutInfoDto.Delay).NotEmpty().WithMessage("Delay can not be null");
            //RuleFor(x => x.updateDeadlineOutInfoDto.Reason).NotEmpty().WithMessage("Reason can not be null");
            //RuleFor(x => x.updateDeadlineOutInfoDto.LastDeadline).NotEmpty().WithMessage("Last Deadline can not be empty");
        }


    }
}
