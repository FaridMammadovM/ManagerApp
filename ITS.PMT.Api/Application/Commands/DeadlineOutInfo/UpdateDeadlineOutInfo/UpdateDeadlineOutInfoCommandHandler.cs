using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.ProjectDetails;
using ITS.PMT.Infrastructure.Repositories.DeadlineOutInfoRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.DeadlineOutInfo.UpdateDeadlineOutInfo
{
    public sealed class UpdateDeadlineOutInfoCommandHandler : IRequestHandler<UpdateDeadlineOutInfoCommand, int>
    {
        private readonly IDeadlineOutInfoRepository _deadlineOutInfoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UpdateDeadlineOutInfoCommand> _validator;

        public UpdateDeadlineOutInfoCommandHandler(IDeadlineOutInfoRepository deadlineOutInfoRepository, IMapper mapper, IValidator<UpdateDeadlineOutInfoCommand> validator)
        {
            _deadlineOutInfoRepository = deadlineOutInfoRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public async Task<int> Handle(UpdateDeadlineOutInfoCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _deadlineOutInfoRepository.UpdateDeadlineOutInfo(_mapper.Map<ProjectDetailsModel>(request.updateDeadlineOutInfoDto));
            return result;
        }
    }
}
