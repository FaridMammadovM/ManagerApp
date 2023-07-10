using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using ITS.PMT.Domain.Models.Comment;

namespace ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository
{
    public interface ICommentRepository
    {
        Task<List<CommentModel>> GetMeetingCommentByMeetingId(int meetingId);

        Task<List<GetCommentAgreedParticipantDto>> GetParticipantByMeetingId(int commentId);
        Task<List<GetCommentNotAgreedParticipantDto>> GetNotParticipantByMeetingId(int commentId);

        Task<int> CreateComment(CommentModel commentModel);
        Task<int> CreateCommentAgreedParticipant(int commentId, List<int> EpmloyeeIds);

    }
}
