using AutoMapper;
using ITS.PMT.Api.Application.Commands.Comment;
using ITS.PMT.Domain.Dto.CommentDtos;
using ITS.PMT.Domain.Models.Comment;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class CommentMappingProfile : Profile
    {

        public CommentMappingProfile()
        {
            CreateMap<CommentModel, CreateCommentDto>().ReverseMap();
            CreateMap<CreateCommentCommand, CreateCommentDto>();
            CreateMap<CommentModel, GetCommentByMeetingIdDto>();

            CreateMap<UpdateCommentDto, CommentModel>();
        }
    }
}
