using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectCountByCategoryWithMonth
{
    public class GetAllProjectCountByCategoryWithMonthQuery : IRequest<List<GetAllProjectCountByCategoryWithMonthDto>>
    {
        public int Id { get; set; }
    }
}