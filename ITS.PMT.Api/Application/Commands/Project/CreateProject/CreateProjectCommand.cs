using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Project.CreateProject
{
    public class CreateProjectCommand : IRequest<int>
    {
        public ProjectForCreationDto projectForCreationDto { get; set; }
    }
}
