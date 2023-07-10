using AutoMapper;
using ITS.PMT.Domain.Dto.GetCommentAgreedParticipantDtos;
using ITS.PMT.Domain.Models.CommentAgreedParticipant;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class CommentAgreedParticipantMappingProfile : Profile
    {

        public CommentAgreedParticipantMappingProfile()
        {
            CreateMap<CommentAgreedParticipantModel, GetCommentAgreedParticipantDto>();
        }
    }
}
