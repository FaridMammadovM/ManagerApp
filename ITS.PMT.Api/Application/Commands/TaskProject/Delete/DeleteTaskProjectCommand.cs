using MediatR;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Delete
{
    public class DeleteTaskProjectCommand : IRequest<int>
    {
        public int Id { get; set; }

    }
}
