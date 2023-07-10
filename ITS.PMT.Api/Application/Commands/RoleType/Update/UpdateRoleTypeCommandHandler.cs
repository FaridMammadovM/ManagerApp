using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.RoleType;
using ITS.PMT.Infrastructure.Repositories.RoleTypeRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.RoleType.Update
{
    public sealed class UpdateRoleTypeCommandHandler : IRequestHandler<UpdateRoleTypeCommand, int>
    {
        private readonly IRoleTypeRepository _roleTypeRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateRoleTypeCommand> _validator;


        public UpdateRoleTypeCommandHandler(IRoleTypeRepository roleTypeRepository, IMapper mapper, IValidator<UpdateRoleTypeCommand> validator)
        {
            _roleTypeRepository = roleTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(UpdateRoleTypeCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _roleTypeRepository.Update(_mapper.Map<RoleTypeModel>(request));
            return result;
        }
    }
}