namespace ITS.PMT.Domain.Dto.MeetingDtos
{
    public class CreateMeetingDto
    {
        public DateTime BeginDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MeetingType_Id { get; set; }
        public string Description { get; set; }
        public string InsertUser { get; set; }
    }
}
