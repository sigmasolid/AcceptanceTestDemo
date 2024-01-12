// Create builder for minimal API
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Create app
var app = builder.Build();

// Setup routes
app.MapGet("/", () => "Hello World!");

// Start app
app.Run();