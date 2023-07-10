using DapperExtension;

namespace ITS.PMT.Domain.Models.CommentAgreedParticipant
{
    [Table(TableName = "comment_agreed_participant", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class CommentAgreedParticipantModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "comment_id")]
        public int CommentId { get; set; }

        [Column(Name = "emp_id")]
        public int EmployeeId { get; set; }

        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }
    }
}
