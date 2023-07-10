using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAdditionallInfo
{
    public class GetAdditionallInfoQuery : IRequest<List<GetAdditionallInfoDto>>
    {
        public int ProjectId { get; set; }
    }
}
