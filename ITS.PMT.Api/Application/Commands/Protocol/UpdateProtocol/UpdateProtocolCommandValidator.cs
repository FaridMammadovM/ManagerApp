using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Protocol.UpdateProtocol
{
    public class UpdateProtocolCommandValidator : AbstractValidator<UpdateProtocolCommand>
    {
        public UpdateProtocolCommandValidator()
        {
            RuleFor(x => x.protocolForUpdateDto.Id).NotEqual(0).WithMessage("Id not empty");
            //RuleFor(x => x.protocolForUpdateDto.UpdateUser).NotEmpty().WithMessage("UpdateUser can not empty");
        }
    }
}
