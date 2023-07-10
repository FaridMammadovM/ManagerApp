using ITS.PMT.Domain.Dto.MeetingDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Meeting.GetMeetingById
{
    public class GetMeetingByIdQuery : IRequest<List<GetMeetingByIdDto>>
    {
        public int Id { get; set; }

    }
}
