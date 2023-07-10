using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.ProtocolRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Protocol.DeleteProtocol
{
    public class DeleteProtocolCommandHandler : IRequestHandler<DeleteProtocolCommand, int>
    {
        private IProtocolRepository _protocolRepository;
        private IValidator<DeleteProtocolCommand> _validator;

        public DeleteProtocolCommandHandler(IProtocolRepository protocolRepository, IValidator<DeleteProtocolCommand> validator)
        {
            _protocolRepository = protocolRepository;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteProtocolCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _protocolRepository.DeletePratocol(request.Id);
            return result;
        }
    }
}
