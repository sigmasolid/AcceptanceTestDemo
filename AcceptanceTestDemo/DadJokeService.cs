namespace AcceptanceTestDemo;

public class DadJokeService : IDadJokeService
{
    private readonly IDadJokeRepository _dadJokeRepository;

    public DadJokeService(IDadJokeRepository dadJokeRepository)
    {
        _dadJokeRepository = dadJokeRepository;
    }

    public DadJoke GetRandomJoke()
    {
        return _dadJokeRepository.GetRandomJoke();
    }

    public DadJoke CreateJoke(DadJoke joke)
    {
        return _dadJokeRepository.CreateJoke(joke);
    }
}

public interface IDadJokeService
{
    DadJoke GetRandomJoke();
    DadJoke CreateJoke(DadJoke joke);
}

public interface IDadJokeRepository
{
    DadJoke GetRandomJoke();
    DadJoke CreateJoke(DadJoke joke);
}

public class InMemoryDadJokeRepository : IDadJokeRepository
{
    private IEnumerable<DadJoke> _jokes = new List<DadJoke>()
    {
        new ("What do you call a fake noodle?", "An impasta"),
    };
    
    public DadJoke GetRandomJoke()
    {
        return _jokes.ElementAt(new Random().Next(0, _jokes.Count()));
    }

    public DadJoke CreateJoke(DadJoke joke)
    {
        _jokes = _jokes.Append(joke);
        return joke;
    }
}