using ITS.PMT.Domain.Dto.CommentProjectDtos;
using ITS.PMT.Domain.Models.CommentProject;

namespace ITS.PMT.Infrastructure.Repositories.CommentProjectRepository
{
    public interface ICommentProjectRepository
    {
        Task<int> CreateComment(CommentProjectModel commentModel);
        public Task<List<GetAllCommentProjectDto>> GetAllCommentProject(int id);
    }
}
