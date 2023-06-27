using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Config Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Reading Note App API", Description="书是别人的，读书笔记才是自己的", Version = "v1" });
});

var app = builder.Build();

// Config Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reading Note App API v1");
});

app.MapGet("/", () => "Welcome to Reading Note App API!");

app.Run();
