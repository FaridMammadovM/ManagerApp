using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.UserPermissionDtos;
using ITS.PMT.Infrastructure.Repositories.UserPermissionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Auth.UserPermission.DeleteUserPermission
{
    public sealed class DeleteUserPermissionCommandHandler : IRequestHandler<DeleteUserPermissionCommand, int>
    {
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteUserPermissionCommand> _validator;


        public DeleteUserPermissionCommandHandler(IUserPermissionRepository userPermissionRepository, IMapper mapper, IValidator<DeleteUserPermissionCommand> validator)
        {
            _userPermissionRepository = userPermissionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteUserPermissionCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _userPermissionRepository.Delete(_mapper.Map<UserDeletePermissionDto>(request));
            return result;
        }
    }
}