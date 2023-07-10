using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Protocol;
using ITS.PMT.Infrastructure.Repositories.ProtocolRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Protocol.CreateProtocol
{
    public class CreateProtocolCommandHandler : IRequestHandler<CreateProtocolCommand, int>
    {

        private readonly IProtocolRepository _protocolRepository;
        private readonly IValidator<CreateProtocolCommand> _validator;
        private readonly IMapper _mapper;
        public CreateProtocolCommandHandler(IProtocolRepository protocolRepository, IMapper mapper, IValidator<CreateProtocolCommand> validator)
        {
            _protocolRepository = protocolRepository;
            _validator = validator;
            _mapper = mapper;

        }

        public async Task<int> Handle(CreateProtocolCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _protocolRepository.CreateProtocol(_mapper.Map<ProtocolModel>(request.protocolForCreateDto));
            return result;
        }
    }
}
