namespace ChatApp.API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
