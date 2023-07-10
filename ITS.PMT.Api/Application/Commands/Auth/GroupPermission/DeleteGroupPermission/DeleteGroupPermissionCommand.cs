using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Commands.Auth.GroupPermission.DeleteGroupPermission
{
    public class DeleteGroupPermissionCommand : IRequest<int>
    {
        public int GroupId { get; set; }
        public List<int> PermissionId { get; set; }
    }
}