using DapperExtension;

namespace ITS.PMT.Domain.Models.Protocol
{

    [Table(TableName = "protocol", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class ProtocolModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "meeting_id")]
        public int MeetingId { get; set; }
        [Column(Name = "emp_id")]
        public int EmployeeId { get; set; }
        [Column(Name = "proj_id")]
        public int ProjectId { get; set; }
        [Column(Name = "description")]
        public string Description { get; set; } = null!;
        [Column(Name = "is_deleted")]
        public int IsDeleted { get; set; }
        [Column(Name = "insert_user")]
        public string InsertUser { get; set; } = null!;
        [Column(Name = "insert_date")]
        public DateTime InsertDate { get; set; } = DateTime.Now;
        [Column(Name = "update_user")]
        public string UpdateUser { get; set; } = null!;
        [Column(Name = "update_date")]
        public DateTime? UpdateDate { get; set; }

    }
}