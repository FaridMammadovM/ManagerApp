using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Commands.Auth.GroupPermission.AddRolePermission
{
    public class AddGroupPermissionCommand : IRequest<int>
    {
        public int GroupId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}
