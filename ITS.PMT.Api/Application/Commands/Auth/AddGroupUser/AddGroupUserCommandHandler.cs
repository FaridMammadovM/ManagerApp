using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Infrastructure.Repositories.RoleTypeUserRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Auth.AddGroupUser
{
    public sealed class AddGroupUserCommandHandler : IRequestHandler<AddGroupUserCommand, int>
    {
        private readonly IRoleTypeUserRepository _roleTypeUserRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<AddGroupUserCommand> _validator;


        public AddGroupUserCommandHandler(IRoleTypeUserRepository roleTypeUserRepository, IMapper mapper, IValidator<AddGroupUserCommand> validator)
        {
            _roleTypeUserRepository = roleTypeUserRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(AddGroupUserCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypeUserRepository.Create(_mapper.Map<RoleTypeUserDto>(request));
            return result;
        }
    }
}

