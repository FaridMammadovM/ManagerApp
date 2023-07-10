using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleTypePermissionDtos;
using ITS.PMT.Infrastructure.Repositories.RoleTypePermisssionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Auth.GroupPermission.DeleteGroupPermission
{
    public sealed class DeleteGroupPermissionCommandHandler : IRequestHandler<DeleteGroupPermissionCommand, int>
    {
        private readonly IGroupPermisssionRepository _roleTypePermisssionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteGroupPermissionCommand> _validator;


        public DeleteGroupPermissionCommandHandler(IGroupPermisssionRepository roleTypePermisssionRepository, IMapper mapper, IValidator<DeleteGroupPermissionCommand> validator)
        {
            _roleTypePermisssionRepository = roleTypePermisssionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteGroupPermissionCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypePermisssionRepository.Delete(_mapper.Map<RoleTypeDeletePermissionDto>(request));
            return result;
        }
    }
}