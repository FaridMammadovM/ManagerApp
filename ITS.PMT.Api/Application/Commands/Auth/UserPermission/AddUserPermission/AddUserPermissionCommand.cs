using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Commands.Auth.UserPermission.AddUserPermission
{
    public class AddUserPermissionCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}
