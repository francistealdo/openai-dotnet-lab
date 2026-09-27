using OpenAI.Chat;

namespace OpenAI.DotNetLab.Api.Services
{
    public class ChatService
    {
        private readonly OpenAIClient _openAIClient;
        private readonly string _model;

        public ChatService(OpenAIClient openAIClient, IConfiguration configuration)
        {
            this._openAIClient =openAIClient;
            this._model = configuration["OpenAI:ChatModel"] ?? "gpt-4o-mini";
        }

        public async Task<string> GetChatResponseAsync(string prompt)
        {
            var chatClient = _openAIClient.GetChatClient(_model);
            var response = await chatClient.CompleteChatAsync(prompt);
            return response.Value.Content[^1].Text ?? "No response generated.";
        }

        public async Task<string> GetChatResponseWithOptionsAsync(string prompt)
        {
            var chatClient = _openAIClient.GetChatClient(_model);
            
            var messages = new List<ChatMessage>
            {
                new UserChatMessage(prompt)
            };

            var options = new ChatCompletionOptions
            {
                Temperature = 0.4f,
                MaxOutputTokenCount = 200,
                TopP = 0.9f,
                FrequencyPenalty = 0.5f,
                PresencePenalty = 0.5f
            };

            var response = await chatClient.CompleteChatAsync(messages, options);
            return response.Value.Content[^1].Text ?? "No response generated.";
        }
    }
}
