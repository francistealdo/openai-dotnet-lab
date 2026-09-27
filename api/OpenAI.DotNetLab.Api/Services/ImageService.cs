using OpenAI.Images;

namespace OpenAI.DotNetLab.Api.Services
{
    public class ImageService
    {
        private readonly OpenAIClient _openAIClient;
        private readonly string _model;

        public ImageService(OpenAIClient openAIClient, IConfiguration configuration)
        {
            this._openAIClient = openAIClient;
            this._model = configuration["OpenAI:ImageModel"] ?? "gpt-image-1-mini";
        }

        public async Task<byte[]> GenerateImageAsync(
    string prompt,
    string quality = "medium",
    int width = 1024,
    int height = 1024)
        {
            var imageClient = _openAIClient.GetImageClient(_model);

            var options = new ImageGenerationOptions
            {
                #pragma warning disable OPENAI001

                Quality = quality.ToLowerInvariant() switch
                {
                    "low" => GeneratedImageQuality.LowQuality,
                    "medium" => GeneratedImageQuality.MediumQuality,
                    "high" => GeneratedImageQuality.High,
                    _ => GeneratedImageQuality.Auto
                },
                Size = GetSize(width, height)
            };

            var response = await imageClient.GenerateImageAsync(prompt, options);

            return response.Value.ImageBytes.ToArray();
        }

        private GeneratedImageSize GetSize(int width, int height)
        {
            return (width, height) switch
            {
                (256, 256) => GeneratedImageSize.W1024xH1024,
                (512, 512) => GeneratedImageSize.W512xH512,
                _ => GeneratedImageSize.W1024xH1024
            };
        }
    }
}
