using ITS.PMT.Domain.Models.Comment;

namespace ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository
{
    public interface IMeetingCommentRepository
    {
        Task<List<CommentModel>> GetMeetingCommentByMeetingId(int meetingId);
        Task<int> UpdateComment(CommentModel commentModel);
        Task<int> UpdateAgreeParticipant(List<int> employeeList, int commentId);

    }
}
