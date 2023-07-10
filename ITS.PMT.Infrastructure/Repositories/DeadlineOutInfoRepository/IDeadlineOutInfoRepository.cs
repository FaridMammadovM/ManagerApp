using ITS.PMT.Domain.Dto.DeadlineOutInfoDtos;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Infrastructure.Repositories.DeadlineOutInfoRepository
{
    public interface IDeadlineOutInfoRepository
    {

        //Task<int> CreateDeadlineOutInfo(ProjectDetailsModel projectDetailsModel);
        Task<int> CreateDeadlineOutInfo(int projectId);

        Task<int> UpdateDeadlineOutInfo(ProjectDetailsModel projectDetailsModel);

        Task<List<GetDeadlineOutInfoDto>> GetDeadlineOutInfoByProjectİd(int projectİd);

    }
}
