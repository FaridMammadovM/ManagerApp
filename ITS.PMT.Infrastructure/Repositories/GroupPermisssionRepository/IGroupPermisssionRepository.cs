using ITS.PMT.Domain.Dto.RoleTypePermissionDtos;

namespace ITS.PMT.Infrastructure.Repositories.RoleTypePermisssionRepository
{
    public interface IGroupPermisssionRepository
    {
        Task<int> Create(RoleTypeAddPermissionDto role);
        Task<int> Delete(RoleTypeDeletePermissionDto role);

    }
}
