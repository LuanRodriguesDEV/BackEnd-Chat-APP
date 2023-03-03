

using SignalRTest.Model;

namespace SignalRTest.DTOS
{
    public class ChatDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public bool Online { get; set; }
        public bool Typing { get; set; }
        public string? Profile { get; set; }
        public ICollection<Messages>? Messages { get; set; }
    }
}
