namespace ITS.PMT.Api.Application.Commands.Comment
{
    public sealed class UpdateCommentDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? UpdateUser { get; set; }
        public List<int>? EmployeeList { get; set; }

    }
}
