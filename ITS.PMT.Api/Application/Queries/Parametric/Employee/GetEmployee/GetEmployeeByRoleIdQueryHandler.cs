using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.ParametricDtos;
using ITS.PMT.Infrastructure.Repositories.ParametricRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Parametric.Employee.GetEmployee
{
    public sealed class GetEmployeeByRoleIdQueryHandler : IRequestHandler<GetEmployeeByRoleIdQuery, List<GetAllEmployeeDto>>
    {
        private readonly IParametricRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetEmployeeByRoleIdQuery> _validator;

        public GetEmployeeByRoleIdQueryHandler(IParametricRepository employeeRepository, IMapper mapper, IValidator<GetEmployeeByRoleIdQuery> validator)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<List<GetAllEmployeeDto>> Handle(GetEmployeeByRoleIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _employeeRepository.GetEmployeeByRoleId(request.RoleId);
            return _mapper.Map<List<GetAllEmployeeDto>>(result);
        }
    }
}
