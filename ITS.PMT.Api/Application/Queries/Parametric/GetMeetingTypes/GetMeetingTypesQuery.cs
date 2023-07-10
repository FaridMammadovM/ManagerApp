using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.MeetingTypes.GetMeetingTypes
{
    public class GetMeetingTypesQuery : IRequest<List<GetMeetingTypesDto>>
    {
    }
}
