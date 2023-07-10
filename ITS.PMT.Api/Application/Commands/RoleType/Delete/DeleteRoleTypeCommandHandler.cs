using AutoMapper;
using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.RoleType.Delete
{
    public sealed class DeleteRoleTypeCommandHandler : IRequestHandler<DeleteRoleTypeCommand, int>
    {
        private readonly IRoleTypeRepository _roleTypeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<DeleteRoleTypeCommand> _validator;


        public DeleteRoleTypeCommandHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper, IValidator<DeleteRoleTypeCommand> validator)
        {
            _roleTypeRepository = roleTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(DeleteRoleTypeCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypeRepository.Delete(request.Id);
            return result;
        }
    }
}
