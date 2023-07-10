using DapperExtension;
using ITS.PMT.Domain.Dto.TeamDtos;
using ITS.PMT.Domain.Models.Team;

namespace ITS.PMT.Infrastructure.Repositories.TeamRepository
{
    public sealed class TeamRepository : ITeamRepository
    {
        private string _conString;
        public TeamRepository(string conString)
        {
            _conString = conString;
        }

        public async Task<int> DeleteTeam(int id)
        {
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                var model = await con.GetByIdAsync<TeamModel>(id);
                if (model == null) return 0;
                model.IsDeleted = 1;
                var response = con.Update(model);
                con.Close();
                return response;


            }
        }

        public async Task<int> CreateTeam(TeamModel teamModel)
        {


            //TeamModel teamModel = new TeamModel()
            //{
            //    EmployeeId = createTeamDto.EmpId,
            //    ProjectId = createTeamDto.ProjectId,
            //    RoleId = createTeamDto.RoleId,
            //    IsDeleted = 0

            //};

            using (var con = DbHelper.GetConn(_conString))
            {
                //string query = $"CreateTeam({createTeamDto.RoleId},{createTeamDto.EmpId})";
                con.Open();
                teamModel.InsertDate = DateTime.Now.ToUniversalTime();
                var teamId = con.InsertReturnId(teamModel);

                //TeamModel res = await con.InsertAsync<TeamModel>(Groupteam, new {});

                con.Close();

                return teamId;
            }
        }

        public async Task<List<GetTeamByProjectIdDto>> GetTeambyProjectId(int projectId)
        {
            string query = $"GetTeamByProjectId({projectId})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetTeamByProjectIdDto> res = (List<GetTeamByProjectIdDto>)con.GetAllPostgreTableValuedFunctionData<GetTeamByProjectIdDto>(query, new { });
                con.Close();
                return res;
            }
        }

        public async Task<List<GetTeamForComboDto>> GetTeamForCombo(int projectid)
        {

            string query = $"getteamforcombo({projectid})";
            using (var con = DbHelper.GetConn(_conString))
            {
                con.Open();
                List<GetTeamForComboDto> res = (List<GetTeamForComboDto>)con.GetAllPostgreTableValuedFunctionData<GetTeamForComboDto>(query, new { });
                con.Close();
                return res;
            }

        }
    }
}
