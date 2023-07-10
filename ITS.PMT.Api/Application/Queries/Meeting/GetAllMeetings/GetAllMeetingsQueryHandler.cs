using ITS.PMT.Domain.Dto.MeetingDtos;
using ITS.PMT.Infrastructure.Repositories.MeetingRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Meeting.GetAllMeetings
{
    public class GetAllMeetingsQueryHandler : IRequestHandler<GetAllMeetingsQuery, List<GetAllMeetingsDto>>
    {
        private readonly IMeetingRepository _meetingRepository;
        public GetAllMeetingsQueryHandler(IMeetingRepository meetingRepository)
        {
            _meetingRepository = meetingRepository;
        }

        public Task<List<GetAllMeetingsDto>> Handle(GetAllMeetingsQuery request, CancellationToken cancellationToken)
        {
            var result = _meetingRepository.GetAllMeetings();
            return result;
        }
    }
}
