using OpenAI.Chat;

namespace OpenAI.DotNetLab.Api.Services
{
    public class RecipeService
    {
        private readonly OpenAIClient _openAIClient;
        private readonly string _model;

        public RecipeService(OpenAIClient openAIClient, IConfiguration configuration)
        {
            this._openAIClient = openAIClient;
            this._model = configuration["OpenAI:ChatModel"] ?? "gpt-4o-mini";
        }

        public async Task<string> GetRecipeAsync(string ingredients, string cuisine, string dietaryRestrictions)
        {
            var chatClient = _openAIClient.GetChatClient(_model);

            var systemMessage = new SystemChatMessage("You are a professional chef that provides creative and easy-to-follow recipes based on user input.");

            var userMessage = new UserChatMessage($"""
                Create a recipe based on the following information:

                Ingredients:
                {ingredients}

                Cuisine:
                {cuisine}

                Dietary restrictions:
                {dietaryRestrictions}

                Include:
                - Recipe name
                - Number of servings
                - Ingredient quantities
                - Preparation time
                - Cooking time
                - Step-by-step instructions
                - Serving suggestions

                Common pantry ingredients may be added when appropriate.
            """);

            var messages = new List<ChatMessage>
            {
                systemMessage,
                userMessage
            };

            var options = new ChatCompletionOptions
            {
                Temperature = 0.4f,
                MaxOutputTokenCount = 500
            };

            var response = await chatClient.CompleteChatAsync(messages, options);
            return response.Value.Content[^1].Text ?? "No response generated.";
        }
    }
}
