using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.ParticipantDtos;
using ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.MeetingParticipant.GetParticipant
{
    public class MeetingParticipantQueryHandler : IRequestHandler<MeetingParticipantQuery, List<GetParticipantByMeetingIdDto>>
    {


        private readonly IMeetingParticipantRepository _meetingParticipantRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<MeetingParticipantQuery> _validator;

        public MeetingParticipantQueryHandler(IMeetingParticipantRepository meetingParticipantRepository, IMapper mapper, IValidator<MeetingParticipantQuery> validator)
        {
            _meetingParticipantRepository = meetingParticipantRepository;
            _mapper = mapper;
            _validator = validator;

        }

        public async Task<List<GetParticipantByMeetingIdDto>> Handle(MeetingParticipantQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _meetingParticipantRepository.GetParticipantByMeetingId(request.MeetingId);
            return _mapper.Map<List<GetParticipantByMeetingIdDto>>(result);
        }
    }
}
