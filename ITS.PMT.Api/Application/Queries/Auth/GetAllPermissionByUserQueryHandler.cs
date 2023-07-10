using AutoMapper;
using ITS.PMT.Domain.Dto.Employee;
using ITS.PMT.Infrastructure.Repositories.EmployeeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Auth
{
    public sealed class GetAllPermissionByUserQueryHandler : IRequestHandler<GetAllPermissionByUserQuery, GetAllPermissionByUserDto>
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IMapper _mapper;


        public GetAllPermissionByUserQueryHandler(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            this.employeeRepository = employeeRepository;
            _mapper = mapper;

        }
        public async Task<GetAllPermissionByUserDto> Handle(GetAllPermissionByUserQuery request, CancellationToken cancellationToken)
        {
            var res = employeeRepository.GetAllPermissionByUserByFin(request.FinNumber).Result;
            if (res != null)
            {
                return res;
            }
            return null;

        }
    }
}