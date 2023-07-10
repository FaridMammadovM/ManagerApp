using DapperExtension;
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
    public sealed class ParametricRepository : IParametricRepository
    {
        private readonly string _conString;
        public ParametricRepository(string conString)
        {
            _conString = conString;
        }
        public async Task<IEnumerable<RoleModel>> GetAllRole()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                IEnumerable<RoleModel> roles = con.GetAll<RoleModel>();
                con.Close();
                return await Task.FromResult(roles);
            }
        }

        public async Task<IEnumerable<StageModel>> GetAllStages()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                IEnumerable<StageModel> stages = con.GetAll<StageModel>().OrderBy(x => x.Id);
                con.Close();

                return stages;
            }
        }

        public async Task<IEnumerable<StatusModel>> GetAllStatus()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                IEnumerable<StatusModel> statuses = con.GetAll<StatusModel>().OrderBy(x => x.Id);
                con.Close();

                return statuses;
            }
        }
        public async Task<List<EmployeeModel>> GetEmployeeByRoleId(int roleId)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<EmployeeModel> check = (List<EmployeeModel>)con.GetByWhere<EmployeeModel>("WHERE\"role_id\" = @RoleId", new { RoleId = roleId });
                con.Close();
                return check;
            }
        }

        public async Task<List<GetProjectNamesDto>> GetProjectNames()
        {
            string query = $"getallprojectnames()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetProjectNamesDto> res = con.GetAllPostgreTableValuedFunctionData<GetProjectNamesDto>(query, new { }).OrderByDescending(x => x.Id).ToList(); ;

                con.Close();
                return res;
            }
        }

        public Task<IEnumerable<MeetingTypes>> GetMeetingTypes()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                IEnumerable<MeetingTypes> meetingTypes = con.GetAll<MeetingTypes>();
                con.Close();
                return Task.FromResult(meetingTypes);
            }
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategory()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                IEnumerable<CategoryModel> statuses = con.GetAll<CategoryModel>().OrderBy(x => x.Id);

                con.Close();

                return statuses;
            }
        }

        public async Task<IEnumerable<PriorityModel>> GetAllPriority()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                IEnumerable<PriorityModel> statuses = con.GetAll<PriorityModel>().OrderBy(x => x.Id);

                con.Close();

                return statuses;
            }
        }

        public async Task<List<GetAllPODto>> GetAllPO()
        {
            string query = $"get_all_po2";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var res = con
                         .GetAllPostgreTableValuedFunctionData<GetAllPODto>($@"{query}()");
                con.Close();

                return await Task.FromResult(res.ToList());
            }
        }

        public async Task<List<GetAllCategoryCountProjectDto>> GetAllCategoryCountProject()
        {
            string query = $"get_categoryid_count_project";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var res = con
                         .GetAllPostgreTableValuedFunctionData<GetAllCategoryCountProjectDto>($@"{query}()");
                con.Close();

                return await Task.FromResult(res.ToList());
            }
        }
    }
}
