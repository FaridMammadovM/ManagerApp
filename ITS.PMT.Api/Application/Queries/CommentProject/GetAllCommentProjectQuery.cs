using ITS.PMT.Domain.Dto.CommentProjectDtos;
using MediatR;
using System.Collections.Generic;

namespace ITS.PMT.Api.Application.Queries.CommentProject
{
    public class GetAllCommentProjectQuery : IRequest<List<GetAllCommentProjectDto>>
    {
        public int Id { get; set; }
    }
}
