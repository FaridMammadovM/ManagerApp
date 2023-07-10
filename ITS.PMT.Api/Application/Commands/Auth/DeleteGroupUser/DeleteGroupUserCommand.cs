using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Commands.Auth.DeleteGroupUser
{
    public class DeleteGroupUserCommand : IRequest<int>
    {
        public int GroupId { get; set; }
        public List<int> UserId { get; set; }
    }
}
