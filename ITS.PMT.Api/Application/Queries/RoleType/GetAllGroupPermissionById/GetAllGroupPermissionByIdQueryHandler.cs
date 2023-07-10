using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleType;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupPermissionById
{
    public sealed class GetAllGroupPermissionByIdQueryHandler : IRequestHandler<GetAllGroupPermissionByIdQuery, RoleTypePermissionAllReturnDto>
    {
        private readonly IRoleTypeRepository roleTypeRepository;
        private readonly IValidator<GetAllGroupPermissionByIdQuery> _validator;
        private readonly IMapper _mapper;


        public GetAllGroupPermissionByIdQueryHandler(IRoleTypeRepository roleTypeRepository, IValidator<GetAllGroupPermissionByIdQuery> validator, IMapper mapper)
        {
            this.roleTypeRepository = roleTypeRepository;
            _validator = validator;
            _mapper = mapper;

        }
        public async Task<RoleTypePermissionAllReturnDto> Handle(GetAllGroupPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = roleTypeRepository.GetAllRolePermissionById(request.Id).Result;
            if (res != null)
            {
                return res;
            }
            return null;

        }
    }
}
