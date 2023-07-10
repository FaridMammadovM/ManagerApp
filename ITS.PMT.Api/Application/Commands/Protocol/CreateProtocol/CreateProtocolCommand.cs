using ITS.PMT.Domain.Dto.ProtocolDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Protocol.CreateProtocol
{
    public class CreateProtocolCommand : IRequest<int>
    {
        public ProtocolForCreateDto protocolForCreateDto { get; set; }
    }
}
