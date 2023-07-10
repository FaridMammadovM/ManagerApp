using DapperExtension;
using ITS.PMT.Domain.Dto.CommentProjectDtos;
using ITS.PMT.Domain.Models.CommentProject;

namespace ITS.PMT.Infrastructure.Repositories.CommentProjectRepository
{
    public sealed class CommentProjectRepository : ICommentProjectRepository
    {

        private string _conString;
        public CommentProjectRepository(string conString)
        {
            _conString = conString;
        }


        public async Task<int> CreateComment(CommentProjectModel commentModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                CommentProjectModel newcommentModel = new CommentProjectModel()
                {
                    Note = commentModel.Note,
                    UserId = commentModel.UserId,
                    ProjectId = commentModel.ProjectId,
                    InsertDate = DateTime.UtcNow
                };
                var id = con.InsertReturnId(newcommentModel);
                con.Close();
                return id;
            }
        }

        public async Task<List<GetAllCommentProjectDto>> GetAllCommentProject(int id)
        {
            string query = $"GetAllProjectComment({id})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetAllCommentProjectDto> res = (List<GetAllCommentProjectDto>)con.GetAllPostgreTableValuedFunctionData<GetAllCommentProjectDto>(query, new { }).OrderBy(x => x.Id).ToList(); ;

                con.Close();
                return res;
            }
        }
    }
}
