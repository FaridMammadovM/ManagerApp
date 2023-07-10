using ITS.PMT.Domain.Dto.TeamDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Team
{
    public class GetTeamByProjectIdQuery : IRequest<List<GetTeamByProjectIdDto>>
    {
        public int ProjectId { get; set; }
    }
}
