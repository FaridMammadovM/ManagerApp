using ITS.PMT.Domain.Dto.DeadlineOutInfoDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.DeadlineOutInfo.GetDeadlineOutInfoByProjectId
{
    public class GetDeadlineOutInfoByProjectIdQuery : IRequest<List<GetDeadlineOutInfoDto>>
    {
        public int ProjectId { get; set; }
        public object GetDeadlineOutInfoDto { get; internal set; }
    }
}
