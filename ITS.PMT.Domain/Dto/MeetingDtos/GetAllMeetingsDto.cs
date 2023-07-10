namespace ITS.PMT.Domain.Dto.MeetingDtos
{
    public class GetAllMeetingsDto
    {
        public int Id { get; set; }
        public int MetTypeId { get; set; }
        public string MeetingType { get; set; }
        public int CommentId { get; set; }
        public string Subject { get; set; }
        public DateTime BeginDate { get; set; }
        public string MetComment { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
        public string Agreed { get; set; }
        public string NotAgreed { get; set; }



    }
}
