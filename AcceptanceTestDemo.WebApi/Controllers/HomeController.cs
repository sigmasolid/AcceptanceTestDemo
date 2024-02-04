using AcceptanceTestDemo.Domain;
using AcceptanceTestDemo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcceptanceTestDemo.WebApi.Controllers;

[ApiController]
public class HomeController(IDadJokeService dadJokeService) : ControllerBase
{
    [HttpGet("/")]
    public IResult GetRandomJoke()
    {
        var joke = dadJokeService.GetRandomJoke();
        return joke is not null ? Results.Ok(joke) : Results.NotFound();
    }
    
    [HttpGet("/{id}")]
    public IResult GetRandomJoke(int jokeId)
    {
        try
        {
            var joke = dadJokeService.GetJoke(jokeId);
            return Results.Ok(joke);
        }
        catch (InvalidOperationException)
        {
            return Results.NotFound();
        }
    }
    
    [HttpPost("/")]
    public IResult CreateJoke(CreateDadJokeRequest joke)
    {
        var createdJoke = dadJokeService.CreateJoke(joke);
        return Results.Created($"/{createdJoke.Id}", createdJoke);
    }
}