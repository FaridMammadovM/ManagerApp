using DapperExtension;
using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using ITS.PMT.Domain.Models.Comment;
using ITS.PMT.Domain.Models.CommentAgreedParticipant;

namespace ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository
{
    public class CommentRepository : ICommentRepository
    {

        private string _conString;
        public CommentRepository(string conString)
        {
            _conString = conString;
        }



        public async Task<List<CommentModel>> GetMeetingCommentByMeetingId(int meetingId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<CommentModel> check = (List<CommentModel>)con.GetByWhere<CommentModel>("WHERE\"meeting_id\" = @MeetingId", new { MeetingId = meetingId });
                con.Close();
                return check;
            }

        }


        public async Task<List<GetCommentAgreedParticipantDto>> GetParticipantByMeetingId(int commentId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                string query = $"getparticipantbycommentid({commentId})";
                List<GetCommentAgreedParticipantDto> res = (List<GetCommentAgreedParticipantDto>)con.GetAllPostgreTableValuedFunctionData<GetCommentAgreedParticipantDto>(query, new { });
                con.Close();
                return res;
            }
        }

        public async Task<List<GetCommentNotAgreedParticipantDto>> GetNotParticipantByMeetingId(int commentId)
        {
            string query = $"getnotparticipantbycommentid({commentId})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetCommentNotAgreedParticipantDto> res = (List<GetCommentNotAgreedParticipantDto>)con.GetAllPostgreTableValuedFunctionData<GetCommentNotAgreedParticipantDto>(query, new { });
                con.Close();
                return res;
            }
        }
        public async Task<int> CreateComment(CommentModel commentModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                CommentModel newcommentModel = new CommentModel()
                {
                    Description = commentModel.Description,
                    InsertUser = commentModel.InsertUser,
                    MeetingId = commentModel.MeetingId,
                    InsertDate = DateTime.Now
                };
                var id = con.InsertReturnId(newcommentModel);
                con.Close();
                return id;
            }
        }

        public async Task<int> CreateCommentAgreedParticipant(int commentId, List<int> EmployeeIds)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                foreach (var item in EmployeeIds)
                {
                    CommentAgreedParticipantModel commentAgreedParticipantModel = new CommentAgreedParticipantModel()
                    {
                        CommentId = commentId,
                        EmployeeId = item
                    };
                    var id = con.InsertReturnId(commentAgreedParticipantModel);
                }

                con.Close();
                return 1;
            }
        }

    }

}
