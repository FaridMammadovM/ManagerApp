namespace ITS.PMT.Domain.Dto.MeetingDtos
{
    public class GetMeetingByIdDto
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int mettypeid { get; set; }
        public string meetingtype { get; set; }
        public string Description { get; set; }
        public string InsertUser { get; set; }

    }
}
