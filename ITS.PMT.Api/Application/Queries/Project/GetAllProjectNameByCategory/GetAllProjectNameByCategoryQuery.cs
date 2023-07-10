using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAllProjectNameByCategory
{
    public class GetAllProjectNameByCategoryQuery : IRequest<List<string>>
    {
        public int Id { get; set; }
    }
}
