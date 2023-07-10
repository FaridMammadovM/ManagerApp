
using FluentValidation;

namespace ITS.PMT.Api.Application.Commands.Protocol.CreateProtocol
{
    public class CreateProtocolCommandValidator : AbstractValidator<CreateProtocolCommand>
    {

        public CreateProtocolCommandValidator()
        {
            RuleFor(t => t.protocolForCreateDto.EmployeeId).NotEqual(0).WithMessage("EmployeeId must not be empty!");
            // RuleFor(t => t.protocolForCreateDto.InsertUser).NotNull().WithMessage("InsertUser must not be empty!");
            RuleFor(t => t.protocolForCreateDto.ProjectId).NotEqual(0).WithMessage("EmployeeId must not be empty!");
            RuleFor(t => t.protocolForCreateDto.MeetingId).NotEqual(0).WithMessage("InsertUser must not be empty!");




        }
    }
}
