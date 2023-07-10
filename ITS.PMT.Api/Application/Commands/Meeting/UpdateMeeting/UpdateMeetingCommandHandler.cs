using AutoMapper;
using ITS.PMT.Domain.Models.Meeting;
using ITS.PMT.Infrastructure.Repositories.MeetingRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Meeting.UpdateMeeting
{
    public class UpdateMeetingCommandHandler : IRequestHandler<UpdateMeetingCommand, int>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
        public UpdateMeetingCommandHandler(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateMeetingCommand request, CancellationToken cancellationToken)
        {
            var result = await _meetingRepository.UpdateMeeting(_mapper.Map<MeetingModel>(request.updateMeetingDto));
            return result;
        }
    }
}
