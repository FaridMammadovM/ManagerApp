using DapperExtension;

namespace ITS.PMT.Domain.Models
{
    public class BaseEntity
    {
        [Column(Name = "id")]
        public int Id { get; set; }

        [Column(Name = "inserted_date")]
        public DateTime InsertedDate { get; set; }

        [Column(Name = "inserted_by")]
        public int UserId { get; set; }

        [Column(Name = "updated_date")]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "updated_by")]
        public int UpdateBy { get; set; }

        [Column(Name = "is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
