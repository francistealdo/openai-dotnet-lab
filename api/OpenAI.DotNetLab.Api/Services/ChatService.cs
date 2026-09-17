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
    }
}
