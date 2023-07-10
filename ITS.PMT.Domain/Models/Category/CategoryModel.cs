using DapperExtension;


namespace ITS.PMT.Domain.Models.Category
{
    [Table(TableName = "category", KeyName = "id", KeyNameInClass = "Id", IsIdentity = true)]
    public class CategoryModel
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "description")]
        public string Description { get; set; } = null!;
    }
}
