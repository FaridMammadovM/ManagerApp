using AutoMapper;
using ITS.PMT.Domain.Models.Comment;
using ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Comment.UpdateComment
{
    public sealed class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, int>
    {
        private readonly IMeetingCommentRepository _meetingCommentRepository;
        private readonly IMapper _mapper;
        public UpdateCommentCommandHandler(IMeetingCommentRepository meetingCommentRepository, IMapper mapper)
        {
            _meetingCommentRepository = meetingCommentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            int updateAgreeParticipant = 0;
            var commentUpdate = await _meetingCommentRepository.UpdateComment(_mapper.Map<CommentModel>(request.updateCommentDto));
            if (commentUpdate != 0) updateAgreeParticipant = await _meetingCommentRepository.UpdateAgreeParticipant(request.updateCommentDto.EmployeeList, request.updateCommentDto.Id);
            return updateAgreeParticipant;
        }
    }
}
