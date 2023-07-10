using DapperExtension;

namespace ITS.PMT.Domain.Models.MeetingTypes
{
    [Table(TableName = "meeting_type", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class MeetingTypes
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "description")]
        public string? Description { get; set; }
    }
}