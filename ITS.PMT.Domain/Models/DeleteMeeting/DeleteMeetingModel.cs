using DapperExtension;

namespace ITS.PMT.Domain.Models.DeleteMeeting
{
    [Table(TableName = "del_meeting", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class DeleteMeetingModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "meeting_id")]
        public int MeetingId { get; set; }
        [Column(Name = "reason")]
        public string Reason { get; set; }
        [Column(Name = "insert_user")]
        public string InsertUser { get; set; }
        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
