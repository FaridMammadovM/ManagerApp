using ITS.PMT.Domain.Dto.RoleTypeUserDtos;

namespace ITS.PMT.Infrastructure.Repositories.RoleTypeUserRepository
{
    public interface IRoleTypeUserRepository
    {
        Task<int> Create(RoleTypeUserDto role);
        Task<int> Delete(RoleTypeDeleteUserDto role);

    }
}
