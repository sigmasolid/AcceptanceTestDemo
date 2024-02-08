using System.Net.Http.Json;
using DadJoke.Domain;
using Shouldly;
using TechTalk.SpecFlow;

namespace DadJoke.WebApi.AcceptanceTests.Steps;

/// <summary>
///    This class contains the step definitions for the dad joke API.
/// </summary>
/// <param name="scenarioContext">
///     ScenarioContext is a dictionary that can be used to share data between steps in a scenario
/// </param>
[Binding]
public sealed class JokeStepDefinitions(
    ScenarioContext scenarioContext,
    HttpClient client)
{
    [Given(@"a joke already exists")]
    public async Task GivenAJokeAlreadyExists()
    {
        var joke = new CreateDadJokeRequest(
            "Why did the scarecrow win an award?",
            "Because he was outstanding in his field.");
        var createdJoke = await CreateJokeAsync(joke);
        scenarioContext.Add("CreatedJoke", createdJoke);
    }

    private async Task<Joke?> CreateJokeAsync(CreateDadJokeRequest joke)
    {
        var httpResponseMessage = await SendCreateJokeRequest(joke);
        var createdJoke = await httpResponseMessage.Content.ReadFromJsonAsync<Joke>();
        return createdJoke;
    }

    private async Task<HttpResponseMessage> SendCreateJokeRequest(CreateDadJokeRequest joke)
    {
        return await client.PostAsJsonAsync("/", joke);
    }

    [When(@"the endpoint for a random joke is called")]
    public async Task WhenTheEndpointForARandomJokeIsCalled()
    {
        var result = await client.GetFromJsonAsync<Joke>("/");
        scenarioContext.Add("Joke", result);
    }

    [Then(@"a joke should be returned")]
    public void ThenAJokeShouldBeReturned()
    {
        var joke = scenarioContext.Get<Joke>("Joke");
        joke.ShouldNotBeNull();
    }
}