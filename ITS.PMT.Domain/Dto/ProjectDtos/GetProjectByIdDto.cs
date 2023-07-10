namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public class GetProjectByIdDto
    {
        public string ProjectName { get; set; } = null!;
        public string ProjectCode { get; set; } = null!;
        public string DepartmentDesc { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
