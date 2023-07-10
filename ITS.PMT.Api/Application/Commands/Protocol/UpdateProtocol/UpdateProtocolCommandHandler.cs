using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Protocol;
using ITS.PMT.Infrastructure.Repositories.ProtocolRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Protocol.UpdateProtocol
{
    public class UpdateProtocolCommandHandler : IRequestHandler<UpdateProtocolCommand, int>
    {
        private readonly IProtocolRepository _protocolRepository;
        private readonly IValidator<UpdateProtocolCommand> _validator;
        private readonly IMapper _mapper;

        public UpdateProtocolCommandHandler(IProtocolRepository protocolRepository, IMapper mapper, IValidator<UpdateProtocolCommand> validator)
        {
            _protocolRepository = protocolRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(UpdateProtocolCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _protocolRepository.UpdateProtocol(_mapper.Map<ProtocolModel>(request.protocolForUpdateDto));
            return result;
        }
    }
}
