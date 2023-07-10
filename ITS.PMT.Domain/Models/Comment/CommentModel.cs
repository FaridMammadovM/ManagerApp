using DapperExtension;


namespace ITS.PMT.Domain.Models.Comment
{
    [Table(TableName = "comment", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]

    public class CommentModel
    {

        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "meeting_id")]
        public int MeetingId { get; set; }

        [Column(Name = "description")]
        public string? Description { get; set; }

        [Column(Name = "insert_user")]
        public string? InsertUser { get; set; }

        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; }

        [Column(Name = "update_user")]
        public string? UpdateUser { get; set; }

        [Column(Name = "update_date")]
        public DateTime UpdateDate { get; set; }

    }
}
