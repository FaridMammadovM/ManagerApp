namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class GetAllProjectsDto
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; }
        public string ProjectManager { get; set; }
        public DateTime DeadLine { get; set; }
        public string Stage { get; set; }
        public string Status { get; set; }
        public int Delay { get; set; }
        public string Reason { get; set; }
        public int ExtraDay { get; set; }
        public DateTime NewDeadLine { get; set; }
        public string Note { get; set; }
    }
}
