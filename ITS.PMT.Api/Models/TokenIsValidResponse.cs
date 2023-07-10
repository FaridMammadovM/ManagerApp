namespace ITS.PMT.Api.Models
{
    public class TokenIsValidResponse
    {
        public bool data { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int status { get; set; }
        public string detail { get; set; }
        public string instance { get; set; }
        public object extensions { get; set; }

    }
}
