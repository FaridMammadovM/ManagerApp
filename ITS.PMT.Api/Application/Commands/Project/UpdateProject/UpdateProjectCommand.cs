using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateProject
{
    public class UpdateProjectCommand : IRequest<int>
    {
        public ProjectForUpdateDto ProjectForUpdateDto { get; set; }
    }
}
