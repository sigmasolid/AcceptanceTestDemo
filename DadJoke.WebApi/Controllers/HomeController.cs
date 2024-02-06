using DadJoke.Domain;
using DadJoke.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DadJoke.WebApi.Controllers;

[ApiController]
public class HomeController(IDadJokeService dadJokeService) : ControllerBase
{
    [HttpGet("/")]
    public ActionResult<Joke> GetRandomJoke()
    {
        var joke = dadJokeService.GetRandomJoke();
        return joke is not null ? joke : NotFound();
    }
    
    [HttpGet("/{id}")]
    public ActionResult<Joke> GetRandomJoke(int jokeId)
    {
        try
        {
            var joke = dadJokeService.GetJoke(jokeId);
            return joke is not null ? joke : NotFound();
        }
        catch (InvalidOperationException)
        {
            return NotFound();
        }
    }
    
    [HttpPost("/")]
    public ActionResult<Joke> CreateJoke(CreateDadJokeRequest joke)
    {
        var createdJoke = dadJokeService.CreateJoke(joke);
        return Created($"/{createdJoke.Id}", createdJoke);
    }
    
    [HttpGet("/health")]
    public ActionResult HealthCheck()
    {
        return Ok();
    }
}