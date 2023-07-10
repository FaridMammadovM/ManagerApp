using AutoMapper;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.MeetingTypes.GetMeetingTypes
{
    public sealed class GetMeetingTypesQueryHandler : IRequestHandler<GetMeetingTypesQuery, List<GetMeetingTypesDto>>
    {
        private readonly IParametricRepository _meetingTypesRepository;
        private readonly IMapper _mapper;
        public GetMeetingTypesQueryHandler(IParametricRepository meetingTypesRepository, IMapper mapper)
        {
            _meetingTypesRepository = meetingTypesRepository;
            _mapper = mapper;
        }
        public async Task<List<GetMeetingTypesDto>> Handle(GetMeetingTypesQuery request, CancellationToken cancellationToken)
        {
            var result = await _meetingTypesRepository.GetMeetingTypes();
            return _mapper.Map<List<GetMeetingTypesDto>>(result);
        }
    }
}
