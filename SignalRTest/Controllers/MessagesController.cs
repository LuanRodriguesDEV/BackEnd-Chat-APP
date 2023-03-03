using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRTest.Model;
using SignalRTest.Services;
using System;


namespace SignalRTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly MessagesService messagesService;

        public MessagesController(MessagesService messagesService)
        {
            this.messagesService = messagesService;
        }
        [HttpPost]
        public async Task <ActionResult<Messages>> Create(Messages message)
        {
            var verify = await messagesService.Create(message);
            return verify != null ? Ok(message) : BadRequest();
        }
    }
}
