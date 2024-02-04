// Create builder for minimal API

using AcceptanceTestDemo.Domain;
using AcceptanceTestDemo.Domain.Interfaces;
using AcceptanceTestDemo.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDadJokeService, DadJokeService>();
builder.Services.AddSingleton<IDadJokeRepository, InMemoryDadJokeRepository>();

// Create app
var app = builder.Build();

// Setup routes
app.MapGet("/", (IDadJokeService jokeService) => jokeService.GetRandomJoke());
app.MapGet("/{id}", (IDadJokeService jokeService) => jokeService.GetRandomJoke());
app.MapPost("/", (IDadJokeService jokeService, CreateDadJokeRequest joke) => jokeService.CreateJoke(joke));

// Start app
app.Run();

// Needed for minimal API to be picked up in the acceptance test project
namespace AcceptanceTestDemo
{
    public partial class Program { }
}

