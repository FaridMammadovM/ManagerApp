namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class GetAllProjectByPODto
    {
        public int Id { get; set; }
        public int Po { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string Projectmanager { get; set; }
        public int Prior_id { get; set; }
        public string Category { get; set; }
        public string Stage_desc { get; set; }
        public string General_status { get; set; }
        public string Current_status { get; set; }
        public List<GetAllProjectTaskNumberDto> GetAllProject { get; set; }
    }
}

