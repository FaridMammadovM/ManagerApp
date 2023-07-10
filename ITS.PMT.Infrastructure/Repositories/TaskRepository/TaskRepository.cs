using DapperExtension;
using ITS.PMT.Domain.Dto.TaskDtos;
using ITS.PMT.Domain.Models.Task;

namespace ITS.PMT.Infrastructure.Repositories.TaskRepository
{
    public sealed class TaskRepository : ITaskRepository
    {
        private string _conString;

        public TaskRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> CreateTask(TaskModel taskModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var id = con.InsertReturnId(taskModel);
                con.Close();
                return id;
            }
        }

        public async Task<int> DeleteTask(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var model = await con.GetByIdAsync<TaskModel>(id);
                if (model == null) return 0;
                model.IsDeleted = 1;
                var response = con.Update(model);
                con.Close();
                return response;


            }
        }

        public async Task<List<TaskModel>> GetTaskById(int id)
        {



            string query = $"gettaskbyid({id})";
            using (var con = DbHelper.GetConn(_conString))
            {

                con.Open();
                List<TaskModel> taskModel = (List<TaskModel>)con.GetAllPostgreTableValuedFunctionData<TaskModel>(query, new { id });
                if (taskModel.Count == 0)
                {
                    return null;

                }
                con.Close();
                return taskModel;
            }

            /*  using (var con = DbHelper.GetConn(_conString))
              {
                  con.Open();

                  TaskModel taskModel = new TaskModel();


                      taskModel = con.GetById<TaskModel>(id);




                  if (taskModel == null) return null;
                  con.Close();
                  return taskModel;
              }
            */
        }

        public async Task<List<GetAllTaskByProjectIdDto>> GetAllTaskByProjectId(int projectId)
        {
            string query = $"gettaskbyprojectid({projectId})";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetAllTaskByProjectIdDto> res = (List<GetAllTaskByProjectIdDto>)con.GetAllPostgreTableValuedFunctionData<GetAllTaskByProjectIdDto>(query, new { });
                con.Close();
                return res;
            }
        }

        public async Task<int> UpdateTask(TaskModel taskModel)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var OldTask = con.GetById<TaskModel>(taskModel.Id);
                if (OldTask == null)
                {
                    return 0;
                }
                OldTask.TaskName = taskModel.TaskName;
                OldTask.TaskNo = taskModel.TaskNo;
                OldTask.StatusId = taskModel.StatusId;
                OldTask.TeamId = taskModel.TeamId;
                OldTask.Deadline = taskModel.Deadline;
                OldTask.EndDate = taskModel.EndDate;
                OldTask.BeginDate = taskModel.BeginDate;
                OldTask.ProjectId = taskModel.ProjectId;
                OldTask.ExecTime = taskModel.ExecTime;
                OldTask.StageId = taskModel.StageId;
                OldTask.Description = taskModel.Description;
                OldTask.PerfIndicator = taskModel.PerfIndicator;

                int id = con.Update(OldTask);
                con.Close();
                return id;
            }
        }

        public async Task<List<GetTasksByProjectIdForGanttChartDto>> GetTasksByProjectIdForGanttChart(int projectId)
        {
            List<GetTasksByProjectIdForGanttChartDto> tasks = new List<GetTasksByProjectIdForGanttChartDto>();
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<TaskModel> res = con.GetAll<TaskModel>().Where(x => x.ProjectId == projectId).OrderBy(x => x.Id).ToList();
                foreach (var item in res)
                {
                    GetTasksByProjectIdForGanttChartDto task = new GetTasksByProjectIdForGanttChartDto()
                    {
                        id = "Task " + item.Id.ToString(),
                        name = item.Description,
                        start = item.BeginDate,
                        end = item.EndDate,
                        progress = item.PerfIndicator,
                        type = "task"
                    };
                    tasks.Add(task);
                }
                con.Close();
            }
            return tasks;
        }
    }
}
