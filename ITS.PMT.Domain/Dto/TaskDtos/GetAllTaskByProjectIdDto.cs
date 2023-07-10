namespace ITS.PMT.Domain.Dto.TaskDtos
{
    public sealed class GetAllTaskByProjectIdDto
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string Stage { get; set; }
        public string TaskName { get; set; }
        public string TaskNo { get; set; }
        public string Employee { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Deadline { get; set; }
        public int ExecTime { get; set; }
        public int PerfIndicator { get; set; }
    }
}
