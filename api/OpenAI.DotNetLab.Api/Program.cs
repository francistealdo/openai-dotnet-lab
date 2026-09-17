using OpenAI.DotNetLab.Api.Extensions;
using OpenAI.DotNetLab.Api.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.AddOpenAI();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ChatService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
