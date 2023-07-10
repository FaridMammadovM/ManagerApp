using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Infrastructure.Repositories.AdditionallInfoRepository
{
    public interface IAdditionallInfoRepository
    {
        int UpdateAdditionallInfo(UpdateAdditionallInfoDto updateAdditionallInfoDto);
        List<ProjectDetailsModel> GetAdditionallInfo(int projectId);
    }
}
