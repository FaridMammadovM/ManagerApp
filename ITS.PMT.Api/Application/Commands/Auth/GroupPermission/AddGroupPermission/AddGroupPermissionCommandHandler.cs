using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleTypePermissionDtos;
using ITS.PMT.Infrastructure.Repositories.RoleTypePermisssionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Auth.GroupPermission.AddRolePermission
{
    public sealed class AddGroupPermissionCommandHandler : IRequestHandler<AddGroupPermissionCommand, int>
    {
        private readonly IGroupPermisssionRepository _roleTypePermisssionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddGroupPermissionCommand> _validator;


        public AddGroupPermissionCommandHandler(IGroupPermisssionRepository roleTypePermisssionRepository, IMapper mapper, IValidator<AddGroupPermissionCommand> validator)
        {
            _roleTypePermisssionRepository = roleTypePermisssionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(AddGroupPermissionCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypePermisssionRepository.Create(_mapper.Map<RoleTypeAddPermissionDto>(request));
            return result;
        }
    }
}
