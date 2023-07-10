using ITS.PMT.Domain.Dto.Employee;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Employee
{
    public class GetAllEmployeeQuery : IRequest<List<GetAllEmployeeDto>>
    {
    }
}
