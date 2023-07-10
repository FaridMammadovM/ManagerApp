namespace ITS.PMT.Domain.Dto.ProjectDtos
{
    public sealed class GetAllProjectManagmentDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public List<GetAllProjectByPODto> GetAll { get; set; }
    }
}
