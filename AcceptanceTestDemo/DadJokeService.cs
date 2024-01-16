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
}

public interface IDadJokeService
{
    DadJoke GetRandomJoke();
}

public interface IDadJokeRepository
{
    DadJoke GetRandomJoke();
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
}