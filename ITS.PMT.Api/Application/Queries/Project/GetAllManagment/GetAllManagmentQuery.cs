using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllManagment
{
    public class GetAllManagmentQuery : IRequest<List<GetAllProjectManagmentDto>>
    {
        public int? CategoryId { get; set; }
        public int? ProductManagerId { get; set; }
        public int? PriorityId { get; set; }
        public int? ProjectId { get; set; }
    }
}