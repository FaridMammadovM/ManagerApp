using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using ITS.PMT.Infrastructure.Repositories.AdditionallInfoRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAdditionallInfo
{
    public sealed class GetAdditionallInfoQueryHandler : IRequestHandler<GetAdditionallInfoQuery, List<GetAdditionallInfoDto>>
    {
        private readonly IAdditionallInfoRepository _additionallInfoRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<GetAdditionallInfoQuery> _validator;



        public GetAdditionallInfoQueryHandler(IAdditionallInfoRepository additionallInfoRepository, IMapper mapper, IValidator<GetAdditionallInfoQuery> validator)
        {
            _additionallInfoRepository = additionallInfoRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<List<GetAdditionallInfoDto>> Handle(GetAdditionallInfoQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = _additionallInfoRepository
                .GetAdditionallInfo(request.ProjectId);

            return _mapper.Map<List<GetAdditionallInfoDto>>(result);
        }
    }
}
