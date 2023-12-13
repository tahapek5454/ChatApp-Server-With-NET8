namespace ChatApp.API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}
