using DapperExtension;

namespace ITS.PMT.Domain.Models.Meeting
{
    [Table(TableName = "meeting", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class MeetingModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "begin_date")]
        public DateTime BeginDate { get; set; }

        [Column(Name = "star_time")]
        public DateTime StartTime { get; set; }

        [Column(Name = "end_time")]
        public DateTime EndTime { get; set; }

        [Column(Name = "meeting_type_id")]
        public int MeetingType_Id { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; }

        [Column(Name = "insert_user")]
        public string InsertUser { get; set; }

        [Column(Name = "update_user")]
        public string UpdateUser { get; set; }

        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; } = DateTime.Now;

        [Column(Name = "update_date")]
        public DateTime? UpdateDate { get; set; }

        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }
    }
}
