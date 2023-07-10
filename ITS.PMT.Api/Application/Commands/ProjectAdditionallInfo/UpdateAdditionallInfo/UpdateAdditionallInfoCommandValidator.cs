using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateAdditionallInfo
{
    public sealed class UpdateAdditionallInfoCommandValidator : AbstractValidator<UpdateAdditionalInfoCommand>
    {
        public UpdateAdditionallInfoCommandValidator()
        {
            RuleFor(x => x.updateAdditionallInfoDto.ProjectId).NotEqual(0).NotEmpty().WithMessage("ProjectId is not empty and zero");
        }
    }
}
