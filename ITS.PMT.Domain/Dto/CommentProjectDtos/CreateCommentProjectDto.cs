namespace ITS.PMT.Domain.Dto.CommentProjectDtos
{
    public sealed class CreateCommentProjectDto
    {

        public int UserId { get; set; }

        public int ProjectId { get; set; }

        public string? Note { get; set; }

    }
}
