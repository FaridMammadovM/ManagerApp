using FluentValidation;
using ITS.PMT.Domain.Dto.DeadlineOutInfoDtos;
using ITS.PMT.Infrastructure.Repositories.DeadlineOutInfoRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.DeadlineOutInfo.GetDeadlineOutInfoByProjectId
{
    public sealed class GetDeadlineOutInfoByProjectIdQueryHandler : IRequestHandler<GetDeadlineOutInfoByProjectIdQuery, List<GetDeadlineOutInfoDto>>
    {
        private readonly IValidator<GetDeadlineOutInfoByProjectIdQuery> _validator;
        private readonly IDeadlineOutInfoRepository _deadlineOutInfoRepository;
        public GetDeadlineOutInfoByProjectIdQueryHandler(IValidator<GetDeadlineOutInfoByProjectIdQuery> validator, IDeadlineOutInfoRepository deadlineOutInfoRepository)
        {
            _validator = validator;
            _deadlineOutInfoRepository = deadlineOutInfoRepository;

        }

        public Task<List<GetDeadlineOutInfoDto>> Handle(GetDeadlineOutInfoByProjectIdQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = _deadlineOutInfoRepository.GetDeadlineOutInfoByProjectİd(request.ProjectId);
            return result;

        }
    }
}
