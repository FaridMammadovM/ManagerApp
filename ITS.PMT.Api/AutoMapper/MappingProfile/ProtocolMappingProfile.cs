using AutoMapper;
using ITS.PMT.Api.Application.Commands.Protocol.CreateProtocol;
using ITS.PMT.Api.Application.Commands.Protocol.UpdateProtocol;
using ITS.PMT.Domain.Dto.ProtocolDtos;
using ITS.PMT.Domain.Models.Protocol;

namespace ITS.PMT.Api.AutoMapper.MappingProfile
{
    public class ProtocolMappingProfile : Profile
    {
        public ProtocolMappingProfile()
        {
            CreateMap<UpdateProtocolCommand, ProtocolModel>();
            CreateMap<CreateProtocolCommand, ProtocolModel>();
            CreateMap<ProtocolForCreateDto, ProtocolModel>();


            CreateMap<ProtocolForUpdateDto, ProtocolModel>();
        }
    }
}
