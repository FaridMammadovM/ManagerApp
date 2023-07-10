using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.DeleteMeeting;
using ITS.PMT.Infrastructure.Repositories.MeetingRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Meeting.DeleteMeeting
{
    public class DeleteMeetingCommandHandler : IRequestHandler<DeleteMeetingCommand, int>
    {
        private readonly IMeetingRepository _meetingRepository;
        private readonly IValidator<DeleteMeetingCommand> _validator;
        private readonly IMapper _mapper;

        public DeleteMeetingCommandHandler(IMeetingRepository meetingRepository, IMapper mapper, IValidator<DeleteMeetingCommand> validator)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(DeleteMeetingCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result1 = await _meetingRepository.DeleteMeeting(request.DeleteMeetingDto.MeetingId);
            if (result1 > 0)
            {
                var result2 = await _meetingRepository.DeleteInsertMeeting(_mapper.Map<DeleteMeetingModel>(request.DeleteMeetingDto));
            }
            return result1;
        }
    }
}
