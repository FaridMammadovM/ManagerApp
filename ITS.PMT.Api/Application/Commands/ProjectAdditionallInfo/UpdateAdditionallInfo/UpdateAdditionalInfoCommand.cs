using ITS.PMT.Domain.Dto.ProjectDetailsDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.Project.UpdateAdditionallInfo
{
    public class UpdateAdditionalInfoCommand : IRequest<int>
    {
        public UpdateAdditionallInfoDto updateAdditionallInfoDto { get; set; }
    }
}
