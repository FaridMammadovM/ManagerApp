namespace ITS.PMT.Domain.Dto.TaskDtos
{
    public sealed class GetTasksByProjectIdForGanttChartDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public int progress { get; set; }

    }
}
