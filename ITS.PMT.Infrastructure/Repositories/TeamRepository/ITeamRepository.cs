using ITS.PMT.Domain.Dto.TeamDtos;
using ITS.PMT.Domain.Models.Team;

namespace ITS.PMT.Infrastructure.Repositories.TeamRepository
{
    public interface ITeamRepository
    {
        public Task<List<GetTeamByProjectIdDto>> GetTeambyProjectId(int projectId);
        public Task<int> CreateTeam(TeamModel teamModel);
        public Task<List<GetTeamForComboDto>> GetTeamForCombo(int projectId);
        Task<int> DeleteTeam(int id);
    }
}
