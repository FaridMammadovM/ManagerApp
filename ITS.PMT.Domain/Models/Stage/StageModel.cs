using DapperExtension;


namespace ITS.PMT.Domain.Models.Stage
{
    [Table(TableName = "stage", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class StageModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }
        [Column(Name = "description")]

        public string Description { get; set; } = null!;

    }
}
