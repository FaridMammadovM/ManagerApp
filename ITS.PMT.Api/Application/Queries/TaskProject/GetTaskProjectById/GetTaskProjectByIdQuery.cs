using ITS.PMT.Domain.Dto.TaskProjectDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Queries.TaskProject.GetTaskProjectById
{
    public class GetTaskProjectByIdQuery : IRequest<TaskProjectByIdDto>
    {
        public int Id { get; set; }
    }

}
