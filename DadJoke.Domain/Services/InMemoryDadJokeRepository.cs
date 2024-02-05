using DadJoke.Domain.Interfaces;

namespace DadJoke.Domain.Services;

public class InMemoryDadJokeRepository : IDadJokeRepository
{
    private IEnumerable<DadJoke> _jokes = new List<DadJoke>();
    
    public DadJoke GetRandomJoke()
    {
        if (!_jokes.Any())
            return null!;
        return _jokes.ElementAt(new Random().Next(0, _jokes.Count()));
    }

    public DadJoke GetJoke(int id)
    {
        return _jokes.SingleOrDefault(x => x.Id == id)!;
    }

    public DadJoke CreateJoke(CreateDadJokeRequest joke)
    {
        var newJoke = new DadJoke(_jokes.Count() + 1, joke.Opening, joke.Punchline);
        _jokes = _jokes.Append(newJoke);
        return newJoke;
    }
}