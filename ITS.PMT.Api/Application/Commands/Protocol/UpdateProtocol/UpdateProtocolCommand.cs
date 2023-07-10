using ITS.PMT.Domain.Dto.ProtocolDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Protocol.UpdateProtocol
{
    public class UpdateProtocolCommand : IRequest<int>
    {
        public ProtocolForUpdateDto protocolForUpdateDto { get; set; }

    }
}
