
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRTest.Model
{
    public class Messages
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public string Message { get; set; } = "";
        public Status Status { get; set; } = Status.Enviado;
        public DateTime CreatedAt { get; set; }  = DateTime.Now;
        public Chat? Chat { get; set; }
        public User? User { get; set; }
    }
    public enum Status
    {
        Enviado,
        Recebida,
        Lida
    }
}
