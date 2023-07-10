using DapperExtension;


namespace ITS.PMT.Domain.Models.CommentProject
{
    [Table(TableName = "comment_project", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class CommentProjectModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "user_id")]
        public int UserId { get; set; }

        [Column(Name = "project_id")]
        public int ProjectId { get; set; }

        [Column(Name = "note")]
        public string? Note { get; set; }

        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; }
    }
}
