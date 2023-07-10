using DapperExtension;

namespace ITS.PMT.Domain.Models.Status
{

    [Table(TableName = "status", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class StatusModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "status_desc")]
        public string Description { get; set; } = null!;

    }
}
