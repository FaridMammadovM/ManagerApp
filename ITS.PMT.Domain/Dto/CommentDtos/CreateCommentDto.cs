namespace ITS.PMT.Domain.Dto.CommentDtos
{
    public sealed class CreateCommentDto
    {
        public string Description { get; set; }
        public int MeetingId { get; set; }
        public string InsertUser { get; set; }

        public List<int> EmployeeIds { get; set; }
    }
}
