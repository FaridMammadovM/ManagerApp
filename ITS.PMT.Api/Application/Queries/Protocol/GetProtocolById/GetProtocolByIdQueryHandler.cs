using FluentValidation;
using ITS.PMT.Domain.Dto.ProtocolDtos;
using ITS.PMT.Infrastructure.Repositories.ProtocolRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Protocol.GetProtocolById
{
    public sealed class GetProtocolByIdQueryHandler : IRequestHandler<GetProtocolByIdQuery, List<GetProtocolsByIdDto>>
    {
        private readonly IProtocolRepository _protocolRepository;
        private readonly IValidator<GetProtocolByIdQuery> _validator;
        public GetProtocolByIdQueryHandler(IProtocolRepository protocolRepository, IValidator<GetProtocolByIdQuery> validator)
        {
            _protocolRepository = protocolRepository;
            _validator = validator;
        }

        public async Task<List<GetProtocolsByIdDto>> Handle(GetProtocolByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _protocolRepository.GetProtocolById(request.Id);
            return result;
        }
    }
}
