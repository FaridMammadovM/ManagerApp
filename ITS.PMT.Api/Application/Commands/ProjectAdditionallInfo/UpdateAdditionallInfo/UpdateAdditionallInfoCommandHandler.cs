using AutoMapper;
using FluentValidation;
using ITS.PMT.Api.Application.Commands.Project.UpdateAdditionallInfo;
using ITS.PMT.Infrastructure.Repositories.AdditionallInfoRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Domain.Dto.ProjectDetailsDtos
{
    public sealed class UpdateAdditionallInfoCommandHandler : IRequestHandler<UpdateAdditionalInfoCommand, int>
    {

        private readonly IAdditionallInfoRepository _additionallInfoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateAdditionalInfoCommand> _validator;

        public UpdateAdditionallInfoCommandHandler(IAdditionallInfoRepository additionallInfoRepository, IMapper mapper, IValidator<UpdateAdditionalInfoCommand> validator)
        {
            _additionallInfoRepository = additionallInfoRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(UpdateAdditionalInfoCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = _additionallInfoRepository
                .UpdateAdditionallInfo(request.updateAdditionallInfoDto);
            return result;
        }
    }
}
