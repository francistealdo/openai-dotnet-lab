namespace OpenAI.DotNetLab.Api.Extensions
{
    public static class OpenAIExtensions
    {
        public static WebApplicationBuilder AddOpenAI(this WebApplicationBuilder builder)
        {
            var apiKey = builder.Configuration["OpenAI:ApiKey"];
            var apiKeySecret = Environment.GetEnvironmentVariable(apiKey);

            if (string.IsNullOrEmpty(apiKeySecret))
            {
                throw new InvalidOperationException("OpenAI API key is not set in the environment variables.");
            }
            ;

            var openAIClient = new OpenAIClient(apiKeySecret);
            builder.Services.AddSingleton(openAIClient);

            return builder;
        }
    }
}
