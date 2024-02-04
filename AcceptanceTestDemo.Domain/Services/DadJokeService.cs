using AcceptanceTestDemo.Domain.Interfaces;

namespace AcceptanceTestDemo.Domain.Services;

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