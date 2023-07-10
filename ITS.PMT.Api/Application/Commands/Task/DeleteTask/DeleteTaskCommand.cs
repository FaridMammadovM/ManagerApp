using MediatR;

namespace ITS.PMT.Api.Application.Commands.Task.DeleteTask
{
    public class DeleteTaskCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
