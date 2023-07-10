namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class ProjectForUpdateDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = null!;
        public string DepartmentDesc { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string UpdateUser { get; set; } = null!;
    }
}
