using ITS.PMT.Domain.Dto.UserPermissionDtos;

namespace ITS.PMT.Infrastructure.Repositories.UserPermissionRepository
{
    public interface IUserPermissionRepository
    {
        Task<int> Create(UserPermissionDto role);
        Task<int> Delete(UserDeletePermissionDto role);

    }
}
