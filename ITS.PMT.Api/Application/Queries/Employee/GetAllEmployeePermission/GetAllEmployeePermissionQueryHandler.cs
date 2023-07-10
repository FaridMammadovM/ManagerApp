using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.Employee;
using ITS.PMT.Infrastructure.Repositories.EmployeeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Employee.GetAllEmployeePermission
{
    public sealed class GetAllEmployeePermissionQueryHandler : IRequestHandler<GetAllEmployeePermissionQuery, EmployeePermissionGetAllDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IValidator<GetAllEmployeePermissionQuery> _validator;
        private readonly IMapper _mapper;


        public GetAllEmployeePermissionQueryHandler(IEmployeeRepository employeeRepository, IValidator<GetAllEmployeePermissionQuery> validator, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            _validator = validator;
            _mapper = mapper;

        }
        public async Task<EmployeePermissionGetAllDto> Handle(GetAllEmployeePermissionQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = employeeRepository.GetAllUserPermissionById(request.Id).Result;
            if (res != null)
            {
                return res;
            }
            return null;

        }
    }
}
