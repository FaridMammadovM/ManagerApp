using DapperExtension;



namespace ITS.PMT.Domain.Models.Priority
{
    [Table(TableName = "priority", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class PriorityModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; } = null!;
    }
}
