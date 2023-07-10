using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAllGroupUserById
{
    public sealed class GetAllGroupUserByIdQueryHandler : IRequestHandler<GetAllGroupUserByIdQuery, RoleTypeUserGetAllDto>
    {
        private readonly IRoleTypeRepository roleTypeRepository;
        private readonly IValidator<GetAllGroupUserByIdQuery> _validator;
        private readonly IMapper _mapper;


        public GetAllGroupUserByIdQueryHandler(IRoleTypeRepository roleTypeRepository, IValidator<GetAllGroupUserByIdQuery> validator, IMapper mapper)
        {
            this.roleTypeRepository = roleTypeRepository;
            _validator = validator;
            _mapper = mapper;

        }
        public async Task<RoleTypeUserGetAllDto> Handle(GetAllGroupUserByIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var res = roleTypeRepository.GetAllRoleUserById(request.Id).Result;
            if (res != null)
            {
                return res;
            }
            return null;

        }
    }
}
