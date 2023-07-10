using DapperExtension;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Domain.Models.Project;
using ITS.PMT.Domain.Models.ProjectDetails;
using System.Text.RegularExpressions;

namespace ITS.PMT.Infrastructure.Repositories.ProjectRepository
{
    public sealed class ProjectRepository : IProjectRepository
    {

        private string _conString;

        public ProjectRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> CreateProject(ProjectModel project)
        {

            using (var con = DbHelper.GetConn(_conString))
            {
                string query = $"get_last_id()";

                int insertProjectId = 0;
                con.Open();

                ProjectModel result = (ProjectModel)con.GetFirstOrDefaultPostgreFunctionData<ProjectModel>(query, new { });
                if (result == null)
                {
                    project.ProjectCode = "PMT0000001";
                    insertProjectId = con.InsertReturnId(project);
                    con.Close();

                    return insertProjectId;
                }
                string pattern = @"^(\D+)(\d+)$";
                Match match = Regex.Match(result.ProjectCode, pattern);

                string prefix = match.Groups[1].Value;
                int numericPart = int.Parse(match.Groups[2].Value);

                numericPart = numericPart + 1;

                project.ProjectCode = prefix + numericPart.ToString("D7");
                insertProjectId = con.InsertReturnId(project);
                con.Close();

                return insertProjectId;
            }

        }
        public async Task<List<ProjectModel>> GetProjectById(int id)
        {

            string query = $"GetProjectById({id})";
            using (var conn = DbHelper.GetConn(_conString))
            {
                conn.Open();
                List<ProjectModel> project = (List<ProjectModel>)conn.GetAllPostgreTableValuedFunctionData<ProjectModel>(query, new { });
                conn.Close();

                return project;
            }
        }


        public async Task<int> UpdateProject(ProjectModel projectModels)
        {
            int id = 0;
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                ProjectModel model = con.GetById<ProjectModel>(projectModels.Id);
                if (model == null)
                {
                    return 0;
                }
                model.ProjectName = projectModels.ProjectName;
                model.DepartmentDesc = projectModels.DepartmentDesc;
                model.Description = projectModels.Description;
                model.UpdateUser = projectModels.UpdateUser;
                model.UpdateDate = DateTime.Now;
                id = con.Update(model);
                con.Close();
            }
            return await Task.FromResult(id);
        }

        public async Task<int> DeleteProject(int id)
        {
            using (var connection = DbHelper.GetConn(_conString))
            {
                connection.Open();


                var model = connection.GetById<ProjectModel>(id);
                if (model == null) return 0;
                model.IsDeleted = 1;
                model.UpdateDate = DateTime.Now;
                var res = await connection.UpdateAsync(model);

                //  var deletedRows = await connection.ExecuteAsync(query, new { id });
                return res;
            };
        }

        public async Task<IEnumerable<ProjectModel>> GetAllProject()
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                IEnumerable<ProjectModel> projects = con.GetAll<ProjectModel>().Where(x => x.IsDeleted == 0).OrderByDescending(x => x.Id);
                con.Close();

                return projects;
            }
        }

        public async Task<List<GetAllProjectsDto>> GetAllProjects()
        {
            string query = $"getallproject()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetAllProjectsDto> res = (List<GetAllProjectsDto>)con.GetAllPostgreTableValuedFunctionData<GetAllProjectsDto>(query, new { }).OrderByDescending(x => x.Id).ToList();

                con.Close();
                return res;
            }
        }

        public async Task<List<GetAllProjectNumberDto>> GetAllProjectByNumber()
        {
            string query = $"get_all_project_last()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                List<GetAllProjectNumberDto> testproject = (List<GetAllProjectNumberDto>)con.GetAllPostgreTableValuedFunctionData<GetAllProjectNumberDto>(query, new { }).OrderByDescending(x => x.Id).ToList();


                con.Close();
                return testproject;
            }
        }

        public async Task<List<GetAllPoIdWithProjectDto>> GetAllPoId()
        {
            string query = $"get_all_project3()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                List<GetAllPoIdWithProjectDto> testproject = (List<GetAllPoIdWithProjectDto>)con.GetAllPostgreTableValuedFunctionData<GetAllPoIdWithProjectDto>(query, new { }).OrderByDescending(x => x.Id).ToList();


                con.Close();
                return testproject;
            }
        }

        public async Task<List<GetAllProjectTaskNumberDto>> GetAllTaskByNumber()
        {
            string query = $"get_all_project_task()";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                List<GetAllProjectTaskNumberDto> task = (List<GetAllProjectTaskNumberDto>)con.GetAllPostgreTableValuedFunctionData<GetAllProjectTaskNumberDto>(query, new { }).OrderByDescending(x => x.Id).ToList();

                con.Close();
                return task;
            }
        }

        public async Task<List<GetAllProjectManagmentDto>> GetAllPO(ManagmentRequestDto data)
        {
            string query = $"get_all_po";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var res = con
                         .GetAllPostgreTableValuedFunctionData<GetAllProjectManagmentDto>($@"{query}(
                       @p_project_id, @p_employee_id)",
                     new
                     {
                         p_project_id = data.ProjectId,
                         p_employee_id = data.ProductManagerId
                     });
                con.Close();

                return await Task.FromResult(res.ToList());
            }
        }

        public async Task<List<GetAllProjectByPODto>> GetAllProjectByPO(ManagmentRequestDto data)
        {

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();


                string baza = "get_all_project22_full";
                var res = con
                         .GetAllPostgreTableValuedFunctionData<GetAllProjectByPODto>($@"{baza}(
                       @p_category_id,  @p_priority_id, @p_project_id)",

                     new
                     {
                         p_category_id = data.CategoryId,
                         p_priority_id = data.PriorityId,
                         p_project_id = data.ProjectId
                     });

                con.Close();

                return await Task.FromResult(res.ToList());

            }
        }

        public async Task<List<GetAllProjectNameDto>> GetAllProjectName()
        {
            string query = $"get_all_project_name";

            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var res = con
                         .GetAllPostgreTableValuedFunctionData<GetAllProjectNameDto>($@"{query}()");
                con.Close();

                return await Task.FromResult(res.ToList());
            }
        }


        public async Task<int> UpdateProjectPriority(ProjectDetailsModel projectModels)
        {
            int id = 0;
            ProjectDetailsModel model = new ProjectDetailsModel();
            using (var con = DbHelper.GetConn(_conString))
            {
                var a = con.GetByWhere<ProjectDetailsModel>("WHERE \"proj_id\"=@proj_id", new { proj_id = projectModels.Id });
                if (a.Count() != 0)
                {
                    model = a.First();
                }
                model.PriorityId = projectModels.PriorityId;
                id = con.Update(model);
                con.Close();

            }
            return await Task.FromResult(id);
        }

        public async Task<List<string>> GetAllProjectNameByCategory(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();


                string baza = "get_all_project_name_bycategoryid";
                var res = con
                         .GetAllPostgreTableValuedFunctionData<string>($@"{baza}(
                       @p_category_id)",

                     new
                     {
                         p_category_id = id

                     });

                con.Close();

                return await Task.FromResult(res.ToList());

            }
        }

        public async Task<List<GetAllProjectCountByCategoryWithMonthDto>> GetAllProjectCountByCategoryWithMonth(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();

                string baza = "calculate_monthly_counts";
                int year = DateTime.Now.Year;
                var res = con
                         .GetAllPostgreTableValuedFunctionData<GetAllProjectCountByCategoryWithMonthDto>($@"{baza}(
                       @p_category_id, @p_year)",
                     new
                     {
                         p_category_id = id,
                         p_year = year
                     });

                con.Close();

                return await Task.FromResult(res.ToList());

            }
        }


    }
}


