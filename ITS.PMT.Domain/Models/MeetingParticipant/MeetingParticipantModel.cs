using DapperExtension;


namespace ITS.PMT.Domain.Models.MeetingParticipant
{
    [Table(TableName = "participant", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class MeetingParticipantModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "meeting_id")]
        public int MeetingId { get; set; }
        [Column(Name = "emp_id")]
        public int EmployeeId { get; set; }
        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }
    }
}
