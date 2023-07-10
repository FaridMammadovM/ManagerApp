using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.MeetingDtos;
using ITS.PMT.Infrastructure.Repositories.MeetingRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Meeting.GetMeetingById
{
    public class GetMeetingByIdQueryHandler : IRequestHandler<GetMeetingByIdQuery, List<GetMeetingByIdDto>>
    {

        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetMeetingByIdQuery> _validator;
        public GetMeetingByIdQueryHandler(IMeetingRepository meetingRepository, IMapper mapper, IValidator<GetMeetingByIdQuery> validator)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
            _validator = validator;
        }


        public async Task<List<GetMeetingByIdDto>> Handle(GetMeetingByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _meetingRepository.GetMeetingById(request.Id);
            return _mapper.Map<List<GetMeetingByIdDto>>(result); ;
        }
    }
}
