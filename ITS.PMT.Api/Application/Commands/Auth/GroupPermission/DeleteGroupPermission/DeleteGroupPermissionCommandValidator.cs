using FluentValidation;
using System.Linq;

namespace ITS.PMT.Api.Application.Commands.Auth.GroupPermission.DeleteGroupPermission
{
    public sealed class DeleteGroupPermissionCommandValidator : AbstractValidator<DeleteGroupPermissionCommand>
    {
        public DeleteGroupPermissionCommandValidator()
        {
            RuleFor(t => t.GroupId).NotNull().WithMessage("GroupId must not be empty!")
                                  .GreaterThan(0).WithMessage("GroupId should be greater than 0");

            RuleFor(t => t.PermissionId)
                   .Must(permissionIds => permissionIds != null && permissionIds.Count > 0)
                   .WithMessage("PermissionId list must not be empty!")
                   .Must(permissionIds => permissionIds.All(id => id > 0))
                   .WithMessage("All PermissionIds should be greater than 0");

        }
    }
}

