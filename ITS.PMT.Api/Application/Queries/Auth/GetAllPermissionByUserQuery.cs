using ITS.PMT.Domain.Dto.Employee;
using MediatR;

namespace ITS.PMT.Api.Application.Queries.Auth
{
    public class GetAllPermissionByUserQuery : IRequest<GetAllPermissionByUserDto>
    {
        public string FinNumber { get; set; }
    }
}
