using AutoMapper;
using ITS.PMT.Domain.Dto.RoleType;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.RoleType.GetAll
{
    public sealed class GetAllNameRoleTypeQueryHandler : IRequestHandler<GetAllNameRoleTypeQuery, List<RoleTypeAllReturnDto>>
    {
        private readonly IRoleTypeRepository roleTypeRepository;
        private readonly IMapper _mapper;


        public GetAllNameRoleTypeQueryHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper)
        {
            this.roleTypeRepository = roleTypeRepository;
            _mapper = mapper;

        }
        public async Task<List<RoleTypeAllReturnDto>> Handle(GetAllNameRoleTypeQuery request, CancellationToken cancellationToken)
        {

            var result = roleTypeRepository.GetAllRoleName().Result;
            //List<RoleTypeAllReturnDto> returnDtos = new List<RoleTypeAllReturnDto>();

            //foreach (var item in result)
            //{
            //    RoleTypeAllReturnDto model = _mapper.Map<RoleTypeAllReturnDto>(item);
            //    returnDtos.Add(model);
            //    return returnDtos;
            //}
            return result;

        }
    }
}

