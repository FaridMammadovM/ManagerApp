namespace ITS.PMT.Domain.Dto.CommentProjectDtos
{
    public sealed class GetAllCommentProjectDto
    {
        public int Id { get; set; }

        public string Full_name { get; set; }

        public int ProjectId { get; set; }

        public string? Note { get; set; }

        public string InsertDate { get; set; }
    }
}
