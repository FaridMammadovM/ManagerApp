using AutoMapper;
using ITS.PMT.Domain.Dto.CommentProjectDtos;
using ITS.PMT.Domain.Models.CommentProject;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class CommentProjectProfile : Profile
    {

        public CommentProjectProfile()
        {
            CreateMap<CommentProjectModel, CreateCommentProjectDto>().ReverseMap();

        }
    }
}

