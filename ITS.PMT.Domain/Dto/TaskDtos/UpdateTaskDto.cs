namespace ITS.PMT.Domain.Dto.TaskDtos
{
    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; } = null!;
        public string TaskNo { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Deadline { get; set; }
        public int ProjectId { get; set; }
        public int StatusId { get; set; }
        public int StageId { get; set; }
        public int TeamId { get; set; }
        public int ExecTime { get; set; }
        public int PerfIndicator { get; set; }

    }
}
