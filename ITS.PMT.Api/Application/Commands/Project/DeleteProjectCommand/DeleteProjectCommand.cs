using MediatR;

namespace ITS.PMT.Api.Application.Commands.Project.DeleteProjectCommand
{
    public class DeleteProjectCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
