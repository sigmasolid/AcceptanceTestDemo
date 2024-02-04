using DadJoke.Domain.Interfaces;

namespace DadJoke.Domain.Services;

public class DadJokeService(IDadJokeRepository dadJokeRepository) : IDadJokeService
{
    public DadJoke GetRandomJoke()
    {
        return dadJokeRepository.GetRandomJoke();
    }

    public DadJoke GetJoke(int id)
    {
        return dadJokeRepository.GetJoke(id);
    }

    public DadJoke CreateJoke(CreateDadJokeRequest joke)
    {
        return dadJokeRepository.CreateJoke(joke);
    }
}