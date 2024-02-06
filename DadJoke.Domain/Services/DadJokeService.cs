using DadJoke.Domain.Interfaces;

namespace DadJoke.Domain.Services;

public class DadJokeService(IDadJokeRepository dadJokeRepository) : IDadJokeService
{
    public Joke GetRandomJoke()
    {
        return dadJokeRepository.GetRandomJoke();
    }

    public Joke GetJoke(int id)
    {
        return dadJokeRepository.GetJoke(id);
    }

    public Joke CreateJoke(CreateDadJokeRequest joke)
    {
        return dadJokeRepository.CreateJoke(joke);
    }
}