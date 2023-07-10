using DapperExtension;
using ITS.PMT.Domain.Dto.DeadlineOutInfoDtos;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Infrastructure.Repositories.DeadlineOutInfoRepository
{
    public sealed class DeadlineOutInfoRepository : IDeadlineOutInfoRepository
    {

        private string _conString;

        public DeadlineOutInfoRepository(string conString)
        {
            _conString = conString;
        }

        //public async Task<int> CreateDeadlineOutInfo(ProjectDetailsModel projectDetailsModel)
        //{
        //    int cretaedDeadlineInfoId = 0;
        //    using (var con = DbHelper.GetConn(_conString))
        //    {
        //        con.Open();
        //        cretaedDeadlineInfoId = con.InsertReturnId(projectDetailsModel);
        //        con.Close();
        //    }
        //    return cretaedDeadlineInfoId;

        //}

        public async Task<int> CreateDeadlineOutInfo(int projectId)
        {
            int cretaedDeadlineInfoId = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                ProjectDetailsModel projectDetails = new ProjectDetailsModel();
                projectDetails.ProjectId = projectId;
                projectDetails.InsertDate = DateTime.UtcNow;
                cretaedDeadlineInfoId = con.InsertReturnId(projectDetails);
                con.Close();
            }
            return cretaedDeadlineInfoId;

        }

        public async Task<List<GetDeadlineOutInfoDto>> GetDeadlineOutInfoByProjectİd(int projectId)
        {

            string query = $"GetDeadlineoutInfoByProjectId({projectId})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetDeadlineOutInfoDto> result = (List<GetDeadlineOutInfoDto>)con.GetAllPostgreTableValuedFunctionData<GetDeadlineOutInfoDto>(query, new { });
                con.Close();
                return result;
            }
        }

        public async Task<int> UpdateDeadlineOutInfo(ProjectDetailsModel projectDetailsModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var updatedDeadlineOutInfo = con.GetByWhere<ProjectDetailsModel>("WHERE \"proj_id\"=@ProjectId", new { ProjectId = projectDetailsModel.ProjectId });


                if (updatedDeadlineOutInfo == null)
                {
                    return 0;
                }
                foreach (var item in updatedDeadlineOutInfo)
                {
                    item.StageId = projectDetailsModel.StageId;
                    item.StatusId = projectDetailsModel.StatusId;
                    item.CategoryId = projectDetailsModel.CategoryId;
                    item.PriorityId = projectDetailsModel.PriorityId;
                    item.CurrentStatus = projectDetailsModel.CurrentStatus;
                    item.GeneralStatus = projectDetailsModel.GeneralStatus;
                    int id = con.Update(item);
                }

                con.Close();
                return 1;
            }
        }
    }
}
