using MediatR;

namespace ITS.PMT.Api.Application.Commands.Group.Create
{
    public class CreateGroupCommand : IRequest<int>
    {
        public int MyProperty { get; set; }
    }
}
