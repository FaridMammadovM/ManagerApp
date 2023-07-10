using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Protocol.DeleteProtocol
{
    public class DeleteProtocolValidator : AbstractValidator<DeleteProtocolCommand>
    {
        public DeleteProtocolValidator()
        {
            RuleFor(x => x.Id).NotEqual(0).NotNull().WithMessage("Id it can not be Empty and 0");
        }
    }
}
