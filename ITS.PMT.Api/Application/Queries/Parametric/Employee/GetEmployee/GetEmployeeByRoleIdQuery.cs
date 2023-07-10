using ITS.PMT.Domain.Dto.ParametricDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Parametric.Employee.GetEmployee
{
    public class GetEmployeeByRoleIdQuery : IRequest<List<GetAllEmployeeDto>>
    {
        public int RoleId { get; set; }
    }
}
