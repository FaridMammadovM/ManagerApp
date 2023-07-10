using ITS.PMT.Domain.Dto.TaskProjectDtos;
using ITS.PMT.Domain.Models.TaskProject;

namespace ITS.PMT.Infrastructure.Repositories.TaskProjectRepository
{
    public interface ITaskProjectRepository
    {
        public Task<int> CreateTaskProject(TaskProjectModel model);
        Task<int> UpdateTaskProject(TaskProjectModel taskModel);

        Task<int> DeleteTask(int id);

        Task<TaskProjectModel> GetById(int id);

        Task<int> ChangeStatusTaskProject(TaskProjectModel taskModel);

        Task<List<GetAllTaskProjectByProjectIdDto>> GetAllTaskProjectByProjectId(int projectId);
    }
}
