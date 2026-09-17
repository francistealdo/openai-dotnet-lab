using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI.DotNetLab.Api.Services;

namespace OpenAI.DotNetLab.Api.Controllers
{
    [ApiController]
    public class GenerativeAIController : ControllerBase
    {
        private readonly ChatService _chatService;

        public GenerativeAIController(ChatService chatService)
        {
            this._chatService = chatService;
        }

        [HttpGet("ask-ai")]
        public async Task<IActionResult> GetChatResponse([FromQuery] string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                return BadRequest("Prompt cannot be empty.");
            }
            var response = await _chatService.GetChatResponseAsync(prompt);
            return Ok(response);
        }
    }
}
