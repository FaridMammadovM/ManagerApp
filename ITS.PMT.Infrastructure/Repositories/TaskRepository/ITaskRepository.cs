using ITS.PMT.Domain.Dto.TaskDtos;
using ITS.PMT.Domain.Models.Task;

namespace ITS.PMT.Infrastructure.Repositories.TaskRepository
{
    public interface ITaskRepository
    {
        Task<int> CreateTask(TaskModel taskModel);
        Task<List<GetAllTaskByProjectIdDto>> GetAllTaskByProjectId(int projectId);
        Task<int> DeleteTask(int id);

        Task<List<TaskModel>> GetTaskById(int id);
        Task<int> UpdateTask(TaskModel taskModel);

        Task<List<GetTasksByProjectIdForGanttChartDto>> GetTasksByProjectIdForGanttChart(int projectId);
    }
}
