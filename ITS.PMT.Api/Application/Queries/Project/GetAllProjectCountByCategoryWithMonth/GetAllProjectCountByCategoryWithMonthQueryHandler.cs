using FluentValidation;
using ITS.PMT.Domain.Dto.ProjectDtos;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectCountByCategoryWithMonth
{
    public sealed class GetAllProjectCountByCategoryWithMonthQueryHandler : IRequestHandler<GetAllProjectCountByCategoryWithMonthQuery, List<GetAllProjectCountByCategoryWithMonthDto>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IValidator<GetAllProjectCountByCategoryWithMonthQuery> _validator;
        public GetAllProjectCountByCategoryWithMonthQueryHandler(IProjectRepository projectRepository, IValidator<GetAllProjectCountByCategoryWithMonthQuery> validator)
        {
            _projectRepository = projectRepository;
            _validator = validator;
        }

        public async Task<List<GetAllProjectCountByCategoryWithMonthDto>> Handle(GetAllProjectCountByCategoryWithMonthQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _projectRepository.GetAllProjectCountByCategoryWithMonth(request.Id);
            return result;
        }
    }
}