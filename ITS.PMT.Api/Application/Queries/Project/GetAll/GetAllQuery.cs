using ITS.PMT.Domain.Dto.ProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.Project.GetAll
{
    public class GetAllQuery : IRequest<List<GetAllProjectNumberDto>>
    {

    }


}
