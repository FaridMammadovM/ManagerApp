using ITS.PMT.Domain.Dto.ParticipantDtos;
using ITS.PMT.Domain.Models.Meeting;
using ITS.PMT.Domain.Models.MeetingParticipant;

namespace ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository
{
    public interface IMeetingParticipantRepository
    {
        Task<int> InsertParticipant(MeetingParticipantModel meetingParticipant);
        Task<int> DeleteMeetingParticipant(int id);
        Task<List<GetParticipantByMeetingIdDto>> GetParticipantByMeetingId(int meetingId);
        Task<List<GetMailsByMeetingIdDto>> GetMailsByMeetingId(int meetingId);
        Task<MeetingModel> GetMeetingId(int meetingId);
    }
}
