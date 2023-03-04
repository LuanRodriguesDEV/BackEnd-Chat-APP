using Microsoft.AspNetCore.SignalR;
using SignalRTest.DTOS;
using SignalRTest.Model;

namespace SignalRTest.Hubs
{
    public class ChatHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"[SIGNALR] Conectado => ID: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
        public async void SendMessage(TypingDTO typingDTO)
        {
            await Clients.All.SendAsync("SendMessage", "Ola");
        }
        public async void Send()
        {

        }
        public async void Typing(TypingDTO typingDTO)
        {
            await Clients.All.SendAsync("Typing", typingDTO);
            Console.WriteLine("Chegou");
        }
        public async void ChangeConnectionID(int id)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, id.ToString());
            Console.WriteLine($"Chat ID: {id}");
        }
        
    }
}
