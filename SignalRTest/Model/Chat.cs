namespace SignalRTest.Model
{
    public class Chat
    {
        public int Id { get; set; } 
        public TypeChat TypeChat { get; set; }
        public ICollection<ChatPeoples>? ChatPeoples { get; set; }
        public ICollection<Messages>? Messages { get; set; }
    }
    public enum TypeChat
    {
        Private = 1,
        Group = 2,
    }
}
