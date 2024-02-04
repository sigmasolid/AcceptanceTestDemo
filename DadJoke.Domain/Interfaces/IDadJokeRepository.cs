namespace DadJoke.Domain.Interfaces;

public interface IDadJokeRepository
{
    DadJoke GetRandomJoke();
    DadJoke CreateJoke(CreateDadJokeRequest joke);
    DadJoke GetJoke(int id);
}