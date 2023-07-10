using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Meeting;
using ITS.PMT.Infrastructure.Repositories.MeetingRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Meeting.CreateMeeting
{
    public class CreateMeetingCommandHandler : IRequestHandler<CreateMeetingCommand, int>
    {

        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateMeetingCommand> _validator;

        public CreateMeetingCommandHandler(IMeetingRepository meetingRepository, IValidator<CreateMeetingCommand> validator, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateMeetingCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _meetingRepository.CreateMeeting(_mapper.Map<MeetingModel>(request.createMeetingDto));
            return result;
        }
    }
}
