using FluentValidation;
using System.Linq;

namespace ITS.PMT.Api.Application.Commands.Auth.DeleteGroupUser
{
    public sealed class DeleteGroupUserCommandValidator : AbstractValidator<DeleteGroupUserCommand>
    {
        public DeleteGroupUserCommandValidator()
        {
            RuleFor(t => t.GroupId).NotNull().WithMessage("GroupId must not be empty!")
                                  .GreaterThan(0).WithMessage("GroupId should be greater than 0");

            RuleFor(t => t.UserId)
                   .Must(UserId => UserId != null && UserId.Count > 0)
                   .WithMessage("UserId list must not be empty!")
                   .Must(UserId => UserId.All(id => id > 0))
                   .WithMessage("All UserIds should be greater than 0");


        }
    }
}