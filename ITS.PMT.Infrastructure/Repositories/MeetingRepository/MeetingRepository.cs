using DapperExtension;
using ITS.PMT.Domain.Dto.MeetingDtos;
using ITS.PMT.Domain.Models.DeleteMeeting;
using ITS.PMT.Domain.Models.Meeting;

namespace ITS.PMT.Infrastructure.Repositories.MeetingRepository
{
    public class MeetingRepository : IMeetingRepository
    {
        private string _conString;

        public MeetingRepository(string conString)
        {
            _conString = conString;
        }


        public async Task<int> CreateMeeting(MeetingModel meetingModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var id = con.InsertReturnId(meetingModel);
                con.Close();
                return id;
            }
        }

        public async Task<int> DeleteMeeting(int MeetingId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var model = con.GetById<MeetingModel>(MeetingId);
                if (model == null)
                {
                    return 0;
                }
                model.IsDeleted = 1;
                var res = await con.UpdateAsync(model);
                return res;
            }
        }

        public async Task<List<GetAllMeetingsDto>> GetAllMeetings()
        {
            string query = $"getallmeetings()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetAllMeetingsDto> res = con.GetAllPostgreTableValuedFunctionData<GetAllMeetingsDto>(query, new { }).OrderByDescending(i => i.Id).ToList();
                con.Close();

                return res;
            }
        }

        public async Task<int> DeleteInsertMeeting(DeleteMeetingModel deleteMeetingModel)
        {

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var id = con.InsertReturnId(deleteMeetingModel);
                if (id == 0)
                {
                    return 0;
                }
                deleteMeetingModel.InsertDate = DateTime.Now;
                con.Close();
                return id;
            }
        }

        public async Task<int> UpdateMeeting(MeetingModel meetingModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                MeetingModel model = con.GetById<MeetingModel>(meetingModel.Id);
                model.BeginDate = meetingModel.BeginDate;
                model.StartTime = meetingModel.StartTime;
                model.EndTime = meetingModel.EndTime;
                model.MeetingType_Id = meetingModel.MeetingType_Id;
                model.Description = meetingModel.Description;
                model.UpdateUser = meetingModel.UpdateUser;
                model.UpdateDate = DateTime.Now;
                var id = con.Update(model);
                con.Close();
                return await Task.FromResult(id);
            }
        }

        public async Task<List<GetMeetingByIdDto>> GetMeetingById(int id)
        {
            string query = $"getmeetingbyid({id})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetMeetingByIdDto> meetingModel = (List<GetMeetingByIdDto>)con.GetAllPostgreTableValuedFunctionData<GetMeetingByIdDto>(query, new { id });
                if (meetingModel.Count == 0)
                {
                    return null;

                }
                con.Close();
                return meetingModel;
            }
        }
    }
}
