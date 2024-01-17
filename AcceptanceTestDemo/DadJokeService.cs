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

    public DadJoke GetJoke(int id)
    {
        return _dadJokeRepository.GetJoke(id);
    }

    public DadJoke CreateJoke(CreateDadJokeRequest joke)
    {
        return _dadJokeRepository.CreateJoke(joke);
    }
}

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

public class InMemoryDadJokeRepository : IDadJokeRepository
{
    private IEnumerable<DadJoke> _jokes = new List<DadJoke>()
    {
        new (1, "What do you call a fake noodle?", "An impasta"),
    };
    
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
        var newJoke = new DadJoke(_jokes.Count() + 1, joke.Joke, joke.Punchline);
        _jokes = _jokes.Append(newJoke);
        return newJoke;
    }
}