using DapperExtension;
using ITS.PMT.Domain.Dto.ParticipantDtos;
using ITS.PMT.Domain.Models.Meeting;
using ITS.PMT.Domain.Models.MeetingParticipant;

namespace ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository
{
    public class MeetingParticipantRepository : IMeetingParticipantRepository
    {
        private string _conString;
        public MeetingParticipantRepository(string conString)
        {
            _conString = conString;
        }
        public async Task<int> InsertParticipant(MeetingParticipantModel meetingParticipant)
        {
            int insertParticipantId = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                insertParticipantId = con.InsertReturnId(meetingParticipant);
                con.Close();
            }
            return insertParticipantId;
        }

        public async Task<int> DeleteMeetingParticipant(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var model = con.GetById<MeetingParticipantModel>(id);
                if (model == null)
                {
                    return 0;
                }
                model.IsDeleted = 1;
                var res = con.Update(model);
                con.Close();
                return res;
            }
        }

        public async Task<List<GetParticipantByMeetingIdDto>> GetParticipantByMeetingId(int meetingId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                string query = $"GetParticipantByMeetingId({meetingId})";

                List<GetParticipantByMeetingIdDto> response = (List<GetParticipantByMeetingIdDto>)con.GetAllPostgreTableValuedFunctionData<GetParticipantByMeetingIdDto>(query, new { });
                con.Close();
                return response;
            }
        }

        public async Task<List<GetMailsByMeetingIdDto>> GetMailsByMeetingId(int meetingId)
        {
            string query = $"GetMailByMeeting({meetingId})";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                IEnumerable<GetMailsByMeetingIdDto> result = con.GetAllPostgreTableValuedFunctionData<GetMailsByMeetingIdDto>(query, new { });
                con.Close();
                return result.ToList();
            }
        }

        public async Task<MeetingModel> GetMeetingId(int meetingId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                MeetingModel result = con.GetById<MeetingModel>(meetingId);
                con.Close();
                return result;
            }
        }
    }
}