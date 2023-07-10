using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.RoleType;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.RoleType.Create
{
    public sealed class CreateRoleTypeCommandHandler : IRequestHandler<CreateRoleTypeCommand, int>
    {
        private readonly IRoleTypeRepository _roleTypeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateRoleTypeCommand> _validator;


        public CreateRoleTypeCommandHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper, IValidator<CreateRoleTypeCommand> validator)
        {
            _roleTypeRepository = roleTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateRoleTypeCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypeRepository.Create(_mapper.Map<RoleTypeModel>(request));
            return result;
        }
    }
}

