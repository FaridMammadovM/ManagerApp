using ITS.PMT.Domain.Dto.MeetingDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Meeting.GetAllMeetings
{
    public class GetAllMeetingsQuery : IRequest<List<GetAllMeetingsDto>>
    {
    }
}
