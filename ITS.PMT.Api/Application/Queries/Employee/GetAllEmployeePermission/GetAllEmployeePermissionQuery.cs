using ITS.PMT.Domain.Dto.Employee;
using MediatR;

namespace ITS.PMT.Api.Application.Queries.Employee.GetAllEmployeePermission
{
    public class GetAllEmployeePermissionQuery : IRequest<EmployeePermissionGetAllDto>
    {
        public int Id { get; set; }
    }
}
