namespace ITS.PMT.Domain.Dto.ParametricDtos
{
    public sealed class GetAllEmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;

    }
}
