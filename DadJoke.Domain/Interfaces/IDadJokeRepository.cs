namespace DadJoke.Domain.Interfaces;

public interface IDadJokeRepository
{
    Joke GetRandomJoke();
    Joke CreateJoke(CreateDadJokeRequest joke);
    Joke GetJoke(int id);
}