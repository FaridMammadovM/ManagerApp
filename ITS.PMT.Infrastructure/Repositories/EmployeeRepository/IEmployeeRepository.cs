using ITS.PMT.Domain.Dto.Employee;

namespace ITS.PMT.Infrastructure.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        public Task<List<GetAllEmployeeDto>> GetAllEmployee();

        Task<EmployeePermissionGetAllDto> GetAllUserPermissionById(int id);

        Task<GetAllPermissionByUserDto> GetAllPermissionByUserByFin(string fin);

    }
}
