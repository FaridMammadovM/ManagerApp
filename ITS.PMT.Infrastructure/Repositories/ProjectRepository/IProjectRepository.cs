using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Domain.Models.Project;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Infrastructure.Repositories.ProjectRepository
{
    public interface IProjectRepository
    {

        Task<int> CreateProject(ProjectModel project);
        Task<List<ProjectModel>> GetProjectById(int id);
        Task<int> UpdateProject(ProjectModel projectModels);
        Task<int> DeleteProject(int id);
        Task<IEnumerable<ProjectModel>> GetAllProject();
        public Task<List<GetAllProjectsDto>> GetAllProjects();

        Task<List<GetAllProjectNumberDto>> GetAllProjectByNumber();

        Task<List<GetAllProjectTaskNumberDto>> GetAllTaskByNumber();
        Task<List<GetAllPoIdWithProjectDto>> GetAllPoId();

        Task<List<GetAllProjectManagmentDto>> GetAllPO(ManagmentRequestDto data);

        Task<List<GetAllProjectByPODto>> GetAllProjectByPO(ManagmentRequestDto data);

        Task<List<GetAllProjectNameDto>> GetAllProjectName();

        Task<int> UpdateProjectPriority(ProjectDetailsModel projectModels);

        Task<List<string>> GetAllProjectNameByCategory(int id);

        Task<List<GetAllProjectCountByCategoryWithMonthDto>> GetAllProjectCountByCategoryWithMonth(int id);


    }
}
