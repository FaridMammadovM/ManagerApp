
using DapperExtension;
using ITS.PMT.Domain.Models.Comment;
using ITS.PMT.Domain.Models.CommentAgreedParticipant;

namespace ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository
{
    public class MeetingCommentRepository : IMeetingCommentRepository
    {


        private string _conString;
        public MeetingCommentRepository(string conString)
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



        public async Task<int> UpdateAgreeParticipant(List<int> employeeList, int commentId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                string temp = "";
                foreach (var item in employeeList)
                {
                    temp += item + ",";

                }


                if (temp != "")
                {

                    string empIds = "'{" + temp.Substring(0, temp.Length - 1) + "}'";
                    var query = $"getparticipant006(:commentId,{empIds})";
                    var updateComment = (List<CommentAgreedParticipantModel>)con.GetAllPostgreTableValuedFunctionData<CommentAgreedParticipantModel>(query, new
                    {
                        commentId = commentId,

                    });
                }
                else
                {
                    var empNullId = "'{" + temp + "}'";
                    var query = $"getparticipant006(:commentId,{empNullId})";
                    var updateComment = (List<CommentAgreedParticipantModel>)con.GetAllPostgreTableValuedFunctionData<CommentAgreedParticipantModel>(query, new
                    {
                        commentId = commentId,

                    });

                }
                return 1;

            }

        }

        public async Task<int> UpdateComment(CommentModel commentModel)
        {
            int result = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var oldComment = con.GetById<CommentModel>(commentModel.Id);
                if (oldComment == null) return 0;
                oldComment.Description = commentModel.Description;
                oldComment.UpdateDate = DateTime.Now;
                oldComment.UpdateUser = commentModel.UpdateUser;
                result = con.Update(oldComment);
            }
            return result;
        }
    }
}
