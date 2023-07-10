using ITS.PMT.Domain.Dto.Employee;
using ITS.PMT.Infrastructure.Repositories.EmployeeRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Employee
{
    public sealed class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, List<GetAllEmployeeDto>>
    {

        private readonly IEmployeeRepository _employeeRepository;
        public GetAllEmployeeQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<GetAllEmployeeDto>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var result = await _employeeRepository.GetAllEmployee();
            return result;
        }
    }
}
