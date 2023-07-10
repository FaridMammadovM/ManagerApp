using FluentValidation;
using ITS.PMT.Infrastructure.Repositories.ProjectRepository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectNameByCategory
{
    public sealed class GetAllProjectNameByCategoryQueryHandler : IRequestHandler<GetAllProjectNameByCategoryQuery, List<string>>
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IValidator<GetAllProjectNameByCategoryQuery> _validator;
        public GetAllProjectNameByCategoryQueryHandler(IProjectRepository projectRepository, IValidator<GetAllProjectNameByCategoryQuery> validator)
        {
            _projectRepository = projectRepository;
            _validator = validator;
        }

        public async Task<List<string>> Handle(GetAllProjectNameByCategoryQuery request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _projectRepository.GetAllProjectNameByCategory(request.Id);
            return result;
        }
    }
}
