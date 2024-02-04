namespace AcceptanceTestDemo.Domain.Interfaces;

public interface IDadJokeService
{
    DadJoke? GetRandomJoke();
    DadJoke? GetJoke(int id);
    DadJoke CreateJoke(CreateDadJokeRequest joke);
}