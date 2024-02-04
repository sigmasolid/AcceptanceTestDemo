using AcceptanceTestDemo.Domain;
using AcceptanceTestDemo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AcceptanceTestDemo.WebApi.Controllers;

[ApiController]
public class HomeController(IDadJokeService dadJokeService) : ControllerBase
{
    [HttpGet("/")]
    public ActionResult<DadJoke> GetRandomJoke()
    {
        var joke = dadJokeService.GetRandomJoke();
        return joke is not null ? joke : NotFound();
    }
    
    [HttpGet("/{id}")]
    public ActionResult<DadJoke> GetRandomJoke(int jokeId)
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
    public ActionResult<DadJoke> CreateJoke(CreateDadJokeRequest joke)
    {
        var createdJoke = dadJokeService.CreateJoke(joke);
        return Created($"/{createdJoke.Id}", createdJoke);
    }
}