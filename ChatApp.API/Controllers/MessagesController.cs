using ChatApp.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController(IMessageService _messageService) : ControllerBase
    {
        [HttpGet("{from}/{to}")]
        public async Task<IActionResult> GetMessages([FromRoute]string from, [FromRoute]string to)
        {
            var response = await _messageService.GetMessagesAsync(from, to);

            return Ok(response);    
        }
    }
}
