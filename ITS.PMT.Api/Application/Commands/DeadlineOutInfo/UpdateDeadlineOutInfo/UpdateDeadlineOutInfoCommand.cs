using ITS.PMT.Domain.Dto.DeadlineOutInfoDtos;
using MediatR;

namespace ITS.PMT.Api.Application.Commands.DeadlineOutInfo.UpdateDeadlineOutInfo
{
    public class UpdateDeadlineOutInfoCommand : IRequest<int>
    {
        public UpdateDeadlineOutInfoDto updateDeadlineOutInfoDto { get; set; }

    }
}
