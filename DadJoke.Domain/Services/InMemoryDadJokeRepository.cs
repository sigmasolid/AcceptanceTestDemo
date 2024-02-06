using DadJoke.Domain.Interfaces;

namespace DadJoke.Domain.Services;

public class InMemoryDadJokeRepository : IDadJokeRepository
{
    private IEnumerable<Joke> _jokes = new List<Joke>();
    
    public Joke GetRandomJoke()
    {
        if (!_jokes.Any())
            return null!;
        return _jokes.ElementAt(new Random().Next(0, _jokes.Count()));
    }

    public Joke GetJoke(int id)
    {
        return _jokes.SingleOrDefault(x => x.Id == id)!;
    }

    public Joke CreateJoke(CreateDadJokeRequest joke)
    {
        var newJoke = new Joke(_jokes.Count() + 1, joke.Opening, joke.Punchline);
        _jokes = _jokes.Append(newJoke);
        return newJoke;
    }
}