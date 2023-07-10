using MediatR;

namespace ITS.PMT.Api.Application.Commands.Protocol.DeleteProtocol
{
    public class DeleteProtocolCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
