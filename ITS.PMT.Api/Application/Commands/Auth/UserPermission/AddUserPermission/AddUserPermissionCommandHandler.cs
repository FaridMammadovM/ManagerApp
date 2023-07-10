using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.UserPermissionDtos;
using ITS.PMT.Infrastructure.Repositories.UserPermissionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Auth.UserPermission.AddUserPermission
{
    public sealed class AddUserPermissionCommandHandler : IRequestHandler<AddUserPermissionCommand, int>
    {
        private readonly IUserPermissionRepository _userPermissionRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddUserPermissionCommand> _validator;


        public AddUserPermissionCommandHandler(IUserPermissionRepository userPermissionRepository, IMapper mapper, IValidator<AddUserPermissionCommand> validator)
        {
            _userPermissionRepository = userPermissionRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(AddUserPermissionCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _userPermissionRepository.Create(_mapper.Map<UserPermissionDto>(request));
            return result;
        }
    }
}