using OpenAI.DotNetLab.Api.Extensions;
using OpenAI.DotNetLab.Api.Services;
using Scalar.AspNetCore;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

builder.AddOpenAI();

builder.Services.AddSingleton<ChatService>();
builder.Services.AddSingleton<ImageService>();
builder.Services.AddSingleton<RecipeService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.AddOpenApi(options =>
    options.AddDocumentTransformer((document, context, _) =>
    {
        document.Info = new()
        {
            Title = "Generative AI API",
            Version = "v1",
            Description = "API for interacting with OpenAI's generative models.",
            Contact = new()
            {
                Name = "OpenAI.DotNetLab",
                Url = new Uri("https://github.com/openai-dotnetlab")
            },
            License = new()
            {
                Name = "MIT License",
                Url = new Uri("https://opensource.org/licenses/MIT")
            },
            TermsOfService = new Uri("https://example.com/terms")
        };
        return Task.CompletedTask;
    }
));

var app = builder.Build();

app.UseCors();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Generative AI API Reference";
        options.Theme = ScalarTheme.Default;
        options.DefaultHttpClient = new(ScalarTarget.Http, ScalarClient.Http11);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
