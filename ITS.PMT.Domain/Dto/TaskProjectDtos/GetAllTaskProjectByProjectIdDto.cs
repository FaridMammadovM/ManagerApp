namespace ITS.PMT.Domain.Dto.TaskProjectDtos
{
    public sealed class GetAllTaskProjectByProjectIdDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }

        public string Deadline { get; set; }

        public string? Reason { get; set; }

        public string? Delay { get; set; }

        public string LastDeadline { get; set; }

        public string? DelayReason { get; set; }

        public int Status { get; set; }
    }
}
