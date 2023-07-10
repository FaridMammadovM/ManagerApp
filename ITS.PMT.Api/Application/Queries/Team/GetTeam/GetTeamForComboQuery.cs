using ITS.PMT.Domain.Dto.TeamDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Team.GetTeam
{
    public class GetTeamForComboQuery : IRequest<IEnumerable<GetTeamForComboDto>>
    {
        public int Projectid { get; set; }
    }
}
