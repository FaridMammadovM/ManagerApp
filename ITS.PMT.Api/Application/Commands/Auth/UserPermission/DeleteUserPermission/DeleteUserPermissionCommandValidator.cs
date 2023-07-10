using FluentValidation;
using System.Linq;


namespace ITS.PMT.Api.Application.Commands.Auth.UserPermission.DeleteUserPermission

{
    public sealed class DeleteUserPermissionCommandValidator : AbstractValidator<DeleteUserPermissionCommand>
    {
        public DeleteUserPermissionCommandValidator()
        {
            RuleFor(t => t.UserId).NotNull().WithMessage("UserId must not be empty!")
                                  .GreaterThan(0).WithMessage("UserId should be greater than 0");

            RuleFor(t => t.PermissionId)
                   .Must(permissionIds => permissionIds != null && permissionIds.Count > 0)
                   .WithMessage("PermissionId list must not be empty!")
                   .Must(permissionIds => permissionIds.All(id => id > 0))
                   .WithMessage("All PermissionIds should be greater than 0");

        }
    }
}