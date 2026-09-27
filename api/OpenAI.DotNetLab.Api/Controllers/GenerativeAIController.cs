using Microsoft.AspNetCore.Mvc;
using OpenAI.DotNetLab.Api.Services;

namespace OpenAI.DotNetLab.Api.Controllers
{
    [ApiController]
    public class GenerativeAIController : ControllerBase
    {
        private readonly ChatService _chatService;
        private readonly RecipeService _recipeService;
        private readonly ImageService _imageService;

        public GenerativeAIController(ChatService chatService, RecipeService recipeService, ImageService imageService)
        {
            this._chatService = chatService;
            this._recipeService = recipeService;
            this._imageService = imageService;
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

        [HttpGet("ask-ai-options")]
        public async Task<IActionResult> GetChatResponseWithOptions([FromQuery] string prompt)
        {
            if (string.IsNullOrWhiteSpace(prompt))
            {
                return BadRequest("Prompt cannot be empty.");
            }
            var response = await _chatService.GetChatResponseWithOptionsAsync(prompt);
            return Ok(response);
        }

        [HttpGet("generate-recipe")]
        public async Task<IActionResult> GenerateRecipe(
            [FromQuery] string ingredients,
            [FromQuery] string cuisine = "any",
            [FromQuery] string dietaryRestrictions = "none")
        {
            if (string.IsNullOrWhiteSpace(ingredients))
            {
                return BadRequest("Ingredients cannot be empty.");
            }
            var response = await _recipeService.GetRecipeAsync(ingredients, cuisine, dietaryRestrictions);
            return Ok(response);
        }

        [HttpGet("generate-image")]
        public async Task<IActionResult> GenerateImage(
            [FromQuery] string prompt,
            [FromQuery] string quality = "medium",
            [FromQuery] int width = 1024,
            [FromQuery] int height = 1024)
        {
            if (string.IsNullOrWhiteSpace(prompt))
                return BadRequest("Prompt cannot be empty.");

            var imageBytes = await _imageService.GenerateImageAsync(
                prompt,
                quality,
                width,
                height);

            return File(imageBytes, "image/png");
        }
    }
}
