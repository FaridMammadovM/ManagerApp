using AutoMapper;
using FluentValidation;
using ITS.PMT.Api.Extensions;
using ITS.PMT.Infrastructure.Repositories.MeetingParticipantRepository;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ITS.PMT.Api.Application.Commands.MeetingParticipant.SendMailParticipant
{
    public class SendMailParticipantCommandHandler : IRequestHandler<SendMailParticipantCommand, int>
    {
        private readonly IMeetingParticipantRepository _meetingParticipantRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<SendMailParticipantCommand> _validator;
        private readonly IConfiguration _configuration;

        public SendMailParticipantCommandHandler(IMeetingParticipantRepository meetingParticipantRepository, IMapper mapper, IValidator<SendMailParticipantCommand> validator, IConfiguration configuration)
        {
            _meetingParticipantRepository = meetingParticipantRepository;
            _mapper = mapper;
            _validator = validator;
            _configuration = configuration;
        }

        public async Task<int> Handle(SendMailParticipantCommand request, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(request);
            var mailList = await _meetingParticipantRepository.GetMailsByMeetingId(request.MeetingId);
            if (mailList.Count != 0)
            {
                var model = await _meetingParticipantRepository.GetMeetingId(request.MeetingId);
                string mailTo = string.Join(", ", mailList.Where(ml => !string.IsNullOrEmpty(ml.Mail)).Select(ml => ml.Mail));
                if (model == null) return 0;
                string template = null;

                if (request.Flag == 1)
                {
                    template = $"Siz iclasa dəvətlisiniz. İclasın başlama tarixi: {model.BeginDate.ToString("yyyy-MM-dd")}  Müddət: {model.StartTime.ToString("HH:mm")} - {model.EndTime.ToString("HH:mm")}";
                }
                else if (request.Flag == 2)
                {
                    template = "İclas texire salindi.";
                }
                if (!string.IsNullOrWhiteSpace(mailTo))
                {
                    var emailResponse = _configuration.SendMail(mailTo.TrimEnd(), $"Iclasın adı: {model.Description}", template);
                }
                return 1;
            }
            return 0;
        }
    }
}
