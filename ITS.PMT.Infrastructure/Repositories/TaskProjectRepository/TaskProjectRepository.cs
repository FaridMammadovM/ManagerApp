using DapperExtension;
using ITS.PMT.Domain.Dto.TaskProjectDtos;
using ITS.PMT.Domain.Models.TaskProject;

namespace ITS.PMT.Infrastructure.Repositories.TaskProjectRepository
{
    public sealed class TaskProjectRepository : ITaskProjectRepository
    {
        private string _conString;
        public TaskProjectRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> CreateTaskProject(TaskProjectModel model)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                model.Status = 1;
                model.InsertDate = DateTime.Now.ToUniversalTime();
                var teamId = con.InsertReturnId(model);

                con.Close();

                return teamId;
            }
        }

        public async Task<int> UpdateTaskProject(TaskProjectModel model)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var OldTask = con.GetById<TaskProjectModel>(model.Id);
                if (OldTask == null)
                {
                    return 0;
                }
                OldTask.TaskName = model.TaskName;
                OldTask.Deadline = model.Deadline;
                OldTask.DateNo = model.DateNo;
                OldTask.Reason = model.Reason;
                OldTask.Delay = model.Delay;
                OldTask.LastDeadline = model.LastDeadline;
                OldTask.DelayReason = model.DelayReason;
                OldTask.UpdateDate = DateTime.Now.ToUniversalTime();

                int id = con.Update(OldTask);
                con.Close();
                return id;
            }
        }

        public async Task<int> DeleteTask(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {

                con.Open();
                var model = await con.GetByIdAsync<TaskProjectModel>(id);
                if (model == null) return 0;
                model.IsDeleted = 1;
                var response = con.Update(model);
                con.Close();
                return response;


            }
        }


        public async Task<TaskProjectModel> GetById(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                TaskProjectModel model = con.GetById<TaskProjectModel>(id);
                con.Close();
                return await Task.FromResult(model);
            }

        }

        public async Task<int> ChangeStatusTaskProject(TaskProjectModel model)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var OldTask = con.GetById<TaskProjectModel>(model.Id);
                if (OldTask == null)
                {
                    return 0;
                }
                OldTask.Status = model.Status;
                OldTask.UpdateDate = DateTime.Now.ToUniversalTime();


                int id = con.Update(OldTask);
                con.Close();
                return id;
            }
        }

        public async Task<List<GetAllTaskProjectByProjectIdDto>> GetAllTaskProjectByProjectId(int projectId)
        {
            string query = $"get_all_projecttask1({projectId})";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetAllTaskProjectByProjectIdDto> res = (List<GetAllTaskProjectByProjectIdDto>)con.GetAllPostgreTableValuedFunctionData<GetAllTaskProjectByProjectIdDto>(query, new { });
                con.Close();
                return res;
            }
        }

    }
}
