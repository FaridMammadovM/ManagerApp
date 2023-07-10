namespace ITS.PMT.Domain.Dto.TaskDtos
{
    public sealed class TaskForGetByIdDto
    {

        public string TaskNo { get; set; } = null!;
        public int StageId { get; set; }
        public int TeamId { get; set; }
        public string TaskName { get; set; } = null!;
        public int PerfIndicator { get; set; }
        public int ExecTime { get; set; }
        public int StatusId { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime BeginDate { get; set; }
        public string Description { get; set; } = null!;

    }
}
