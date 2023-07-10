using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.RoleTypeUserDtos;
using ITS.PMT.Infrastructure.Repositories.RoleTypeUserRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Auth.DeleteGroupUser
{
    public sealed class DeleteGroupUserCommandHandler : IRequestHandler<DeleteGroupUserCommand, int>
    {
        private readonly IRoleTypeUserRepository _roleTypeUserRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteGroupUserCommand> _validator;


        public DeleteGroupUserCommandHandler(IRoleTypeUserRepository roleTypeUserRepository, IMapper mapper, IValidator<DeleteGroupUserCommand> validator)
        {
            _roleTypeUserRepository = roleTypeUserRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteGroupUserCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypeUserRepository.Delete(_mapper.Map<RoleTypeDeleteUserDto>(request));
            return result;
        }
    }
}