using AutoMapper;
using FluentValidation;
using ITS.PMT.Domain.Models.Comment;
using ITS.PMT.Infrastructure.Repositories.MeetingCommentRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.Comment
{
    public sealed class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCommentCommand> _validator;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, IValidator<CreateCommentCommand> validator)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var result = await _commentRepository.CreateComment(_mapper.Map<CommentModel>(request.createCommentDto));
            if (result == 0)
            {
                return 0;
            }
            else
            {
                var result2 = _commentRepository.CreateCommentAgreedParticipant(result, request.createCommentDto.EmployeeIds);
                return result;
            }
        }
    }
}
