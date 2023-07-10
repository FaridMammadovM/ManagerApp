using ITS.PMT.Domain.Dto.MeetingDtos;
using ITS.PMT.Domain.Models.DeleteMeeting;
using ITS.PMT.Domain.Models.Meeting;

namespace ITS.PMT.Infrastructure.Repositories.MeetingRepository
{
    public interface IMeetingRepository
    {
        Task<int> CreateMeeting(MeetingModel meetingModel);
        Task<int> UpdateMeeting(MeetingModel meetingModel);
        Task<List<GetAllMeetingsDto>> GetAllMeetings();
        Task<int> DeleteMeeting(int MeetingId);
        Task<int> DeleteInsertMeeting(DeleteMeetingModel deleteMeetingModel);
        Task<List<GetMeetingByIdDto>> GetMeetingById(int id);

    }
}
