namespace DadJoke.Domain.Interfaces;

public interface IDadJokeService
{
    Joke? GetRandomJoke();
    Joke? GetJoke(int id);
    Joke CreateJoke(CreateDadJokeRequest joke);
}