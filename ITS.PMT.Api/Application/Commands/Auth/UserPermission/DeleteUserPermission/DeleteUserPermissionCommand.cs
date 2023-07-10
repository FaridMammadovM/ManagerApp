using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Commands.Auth.UserPermission.DeleteUserPermission
{
    public class DeleteUserPermissionCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}