using MediatR;

namespace ITS.PMT.Api.Application.Commands.TaskProject.ChangeStatus
{
    public class ChangeStatusTaskProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Status { get; set; }

    }
}
