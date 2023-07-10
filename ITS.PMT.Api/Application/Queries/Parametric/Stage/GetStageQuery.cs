using ITS.PMT.Domain.Dto.StageDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Stage
{
    public class GetStageQuery : IRequest<List<GetStageDto>>
    {
    }
}
