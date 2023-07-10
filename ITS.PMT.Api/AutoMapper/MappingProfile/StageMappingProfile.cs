using AutoMapper;
using ITS.PMT.Domain.Dto.StageDtos;
using ITS.PMT.Domain.Models.Stage;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class StageMappingProfile : Profile
    {
        public StageMappingProfile()
        {
            CreateMap<StageModel, GetStageDto>();
        }
    }
}
