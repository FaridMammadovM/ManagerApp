using MediatR;
using System;

namespace ITS.PMT.Api.Application.Commands.TaskProject.Create
{
    public class CreateTaskProjectCommand : IRequest<int>
    {
        public string TaskName { get; set; }

        public DateTime Deadline { get; set; }

        public int DateNo { get; set; }

        public string? Reason { get; set; }

        public int? Delay { get; set; }

        public DateTime? LastDeadline { get; set; }

        public string? DelayReason { get; set; }

        public int ProjectId { get; set; }
    }
}
