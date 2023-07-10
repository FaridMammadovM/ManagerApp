using MediatR;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateProjectPriority
{
    public class UpdateProjectPriorityCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int PriorityId { get; set; }
    }
}
