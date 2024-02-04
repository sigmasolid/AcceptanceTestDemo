using AcceptanceTestDemo.Domain.Interfaces;

namespace AcceptanceTestDemo.Domain.Services;

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