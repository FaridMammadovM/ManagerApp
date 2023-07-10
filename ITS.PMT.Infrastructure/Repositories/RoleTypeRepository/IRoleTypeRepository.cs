using ITS.PMT.Domain.Dto.RoleType;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Domain.Models.RoleType;

namespace ITS.PMT.Infrastructure.Repositories.RoleTypeRepository
{
    public interface IRoleTypeRepository
    {
        Task<int> Create(RoleTypeModel role);
        Task<int> Update(RoleTypeModel role);
        Task<int> Delete(int id);

        Task<RoleTypeModel> GetRoleById(int id);
        Task<List<RoleTypeAllReturnDto>> GetAllRoleName();
        Task<RoleTypePermissionAllReturnDto> GetAllRolePermissionById(int id);

        Task<RoleTypeUserGetAllDto> GetAllRoleUserById(int id);


    }
}
