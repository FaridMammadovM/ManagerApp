using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleType;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetById
{
    public sealed class GetByIdRoleTypeQueryHandler : IRequestHandler<GetByIdRoleTypeQuery, RoleTypeGetByIdDto>
    {
        private readonly IRoleTypeRepository roleTypeRepository;
        private readonly IValidator<GetByIdRoleTypeQuery> _validator;
        private readonly IMapper _mapper;


        public GetByIdRoleTypeQueryHandler(IRoleTypeRepository roleTypeRepository, IValidator<GetByIdRoleTypeQuery> validator, IMapper mapper)
        {
            this.roleTypeRepository = roleTypeRepository;
            _validator = validator;
            _mapper = mapper;

        }
        public async Task<RoleTypeGetByIdDto> Handle(GetByIdRoleTypeQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = roleTypeRepository.GetRoleById(request.Id).Result;
            if (res != null)
            {
                RoleTypeGetByIdDto employee = _mapper.Map<RoleTypeGetByIdDto>(res);
                return employee;
            }
            return null;

        }
    }
}
