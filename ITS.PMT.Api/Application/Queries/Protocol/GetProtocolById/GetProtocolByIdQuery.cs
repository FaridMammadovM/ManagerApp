using ITS.PMT.Domain.Dto.ProtocolDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Protocol.GetProtocolById
{
    public class GetProtocolByIdQuery : IRequest<List<GetProtocolsByIdDto>>
    {
        public int Id { get; set; }
    }
}
