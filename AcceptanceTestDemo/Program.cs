// Create builder for minimal API

using AcceptanceTestDemo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDadJokeService, DadJokeService>();
builder.Services.AddSingleton<IDadJokeRepository, InMemoryDadJokeRepository>();

// Create app
var app = builder.Build();

// Setup routes
app.MapGet("/", (IDadJokeService jokeService) => jokeService.GetRandomJoke());
app.MapPost("/", (IDadJokeService jokeService, DadJoke joke) => jokeService.CreateJoke(joke));

// Start app
app.Run();

public record DadJoke(string Joke, string Punchline);