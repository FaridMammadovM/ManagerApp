using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Domain.Models.Category;
using ITS.PMT.Domain.Models.Employee;
using ITS.PMT.Domain.Models.MeetingTypes;
using ITS.PMT.Domain.Models.Priority;
using ITS.PMT.Domain.Models.Role;
using ITS.PMT.Domain.Models.Stage;
using ITS.PMT.Domain.Models.Status;

namespace ITS.PMT.Infrastructure.Repositories.ParametricRepository
{
    public interface IParametricRepository
    {
        Task<IEnumerable<RoleModel>> GetAllRole();
        Task<IEnumerable<StageModel>> GetAllStages();
        Task<IEnumerable<StatusModel>> GetAllStatus();
        Task<List<GetProjectNamesDto>> GetProjectNames();

        Task<IEnumerable<MeetingTypes>> GetMeetingTypes();
        Task<List<EmployeeModel>> GetEmployeeByRoleId(int roleId);

        Task<IEnumerable<CategoryModel>> GetAllCategory();

        Task<IEnumerable<PriorityModel>> GetAllPriority();
        Task<List<GetAllPODto>> GetAllPO();
        Task<List<GetAllCategoryCountProjectDto>> GetAllCategoryCountProject();

    }
}
