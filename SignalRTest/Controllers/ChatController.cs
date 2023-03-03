using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRTest.DTOS;
using SignalRTest.Model;
using SignalRTest.Services;
using System;
using System.Runtime.CompilerServices;


namespace SignalRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly ChatServices chatServices;

        public ChatController(ChatServices chatServices)
        {
            this.chatServices = chatServices;
        }
        [HttpPost("{id}")]
        public async Task <ActionResult<ChatDTO>> Create(Chat chat,int id)
        {
            var verify = await chatServices.Create(chat,id);
            return verify != null ? Ok(verify) : BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ChatDTO>>> GetMyChats (int id)
        {
            var verify = await chatServices.GetMyChats(id);
            return verify != null ? Ok(verify) : BadRequest();
        }
    }
}
