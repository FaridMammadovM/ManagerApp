using AutoMapper;
using ITS.PMT.Domain.Dto.DeadlineOutInfoDtos;
using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using ITS.PMT.Domain.Models.ProjectDetails;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class DeadlineOutİnfoMappingProfile : Profile
    {

        public DeadlineOutİnfoMappingProfile()
        {
            CreateMap<CreateDeadlineOutInfoDto, ProjectDetailsModel>();
            CreateMap<UpdateDeadlineOutInfoDto, ProjectDetailsModel>();
            CreateMap<GetAdditionallInfoDto, ProjectDetailsModel>();

        }


    }
}
