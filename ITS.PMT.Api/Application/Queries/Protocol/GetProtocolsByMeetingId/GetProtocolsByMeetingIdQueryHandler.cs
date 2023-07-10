using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.ProtocolDtos;
using ITS.PMT.Infrastructure.Repositories.ProtocolRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Protocol.GetProtocolsByMeetingId
{
    public sealed class GetProtocolsByMeetingIdQueryHandler : IRequestHandler<GetProtocolsByMeetingIdQuery, List<GetProtocolsByMeetingIdDto>>
    {
        private readonly IProtocolRepository _protocolRepository;
        private readonly IValidator<GetProtocolsByMeetingIdQuery> _validator;
        public GetProtocolsByMeetingIdQueryHandler(IProtocolRepository protocolRepository, IMapper mapper, IValidator<GetProtocolsByMeetingIdQuery> validator)
        {
            _protocolRepository = protocolRepository;
            _validator = validator;
        }
        public async Task<List<GetProtocolsByMeetingIdDto>> Handle(GetProtocolsByMeetingIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _protocolRepository.GetProtocolsByMeetingId(request.MeetingId);
            return result;
        }
    }
}
