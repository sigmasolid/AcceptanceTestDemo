namespace AcceptanceTestDemo;

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

# region Interfaces
public interface IDadJokeService
{
    DadJoke GetRandomJoke();
    DadJoke GetJoke(int id);
    DadJoke CreateJoke(CreateDadJokeRequest joke);
}

public interface IDadJokeRepository
{
    DadJoke GetRandomJoke();
    DadJoke CreateJoke(CreateDadJokeRequest joke);
    DadJoke GetJoke(int id);
}
# endregion

public class InMemoryDadJokeRepository : IDadJokeRepository
{
    private IEnumerable<DadJoke> _jokes = new List<DadJoke>();
    
    public DadJoke GetRandomJoke()
    {
        return _jokes.ElementAt(new Random().Next(0, _jokes.Count()));
    }

    public DadJoke GetJoke(int id)
    {
        return _jokes.Single(x => x.Id == id);
    }

    public DadJoke CreateJoke(CreateDadJokeRequest joke)
    {
        var newJoke = new DadJoke(_jokes.Count() + 1, joke.Opening, joke.Punchline);
        _jokes = _jokes.Append(newJoke);
        return newJoke;
    }
}