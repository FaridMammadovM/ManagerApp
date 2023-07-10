using ITS.PMT.Domain.Dto.ProtocolDtos;
using ITS.PMT.Domain.Models.Protocol;

namespace ITS.PMT.Infrastructure.Repositories.ProtocolRepository
{
    public interface IProtocolRepository
    {
        Task<int> UpdateProtocol(ProtocolModel protocolModel);
        Task<List<GetProtocolsByMeetingIdDto>> GetProtocolsByMeetingId(int meetingId);
        Task<int> CreateProtocol(ProtocolModel protocolModel);


        Task<int> DeletePratocol(int id);
        Task<List<GetProtocolsByIdDto>> GetProtocolById(int id);
    }
}
