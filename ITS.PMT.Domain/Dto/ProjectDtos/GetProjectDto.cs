namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class GetProjectDto
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }
        public string ProjectCode { get; set; }
        public string? DepartmentDesc { get; set; }
        public string Description { get; set; } = null!;
    }
}
