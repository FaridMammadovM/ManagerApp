using DapperExtension;
using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Infrastructure.Repositories.AdditionallInfoRepository
{
    public sealed class AdditionallinfoRepository : IAdditionallInfoRepository
    {

        private string _conString;

        public AdditionallinfoRepository(string conString)
        {
            _conString = conString;
        }
        public List<ProjectDetailsModel> GetAdditionallInfo(int projectId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                var query = $"get_additional_info({projectId})";
                con.Open();
                List<ProjectDetailsModel> getProjectDetails = (List<ProjectDetailsModel>)con.GetAllPostgreTableValuedFunctionData<ProjectDetailsModel>(query, new { });
                if (getProjectDetails.Count == 0)
                {
                    return null;
                }
                con.Close();
                return getProjectDetails;
            }
        }

        public int UpdateAdditionallInfo(UpdateAdditionallInfoDto updateAdditionallInfoDto)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                var query = $"get_additional_info({updateAdditionallInfoDto.ProjectId})";
                con.Open();
                List<ProjectDetailsModel> getProjectDetails = (List<ProjectDetailsModel>)con.GetAllPostgreTableValuedFunctionData<ProjectDetailsModel>(query, new { });
                if (getProjectDetails.Count == 0)
                {
                    return 0;
                }

                foreach (var element in getProjectDetails)
                {
                    element.StageId = updateAdditionallInfoDto.StageId;
                    element.StatusId = updateAdditionallInfoDto.StatusId;
                    element.CategoryId = updateAdditionallInfoDto.CategoryId;
                    element.PriorityId = updateAdditionallInfoDto.PriorityId;
                    element.CurrentStatus = updateAdditionallInfoDto.CurrentStatus;
                    element.GeneralStatus = updateAdditionallInfoDto.GeneralStatus;
                    element.UpdateDate = DateTime.UtcNow;
                    con.Update(element);
                }
                con.Close();
                return 1;

            }
        }
    }
}
