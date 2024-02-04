using System.Net.Http.Json;
using AcceptanceTestDemo.AcceptanceTests.Constants;
using Shouldly;
using TechTalk.SpecFlow;

namespace AcceptanceTestDemo.AcceptanceTests.Steps;

/// <summary>
///    This class contains the step definitions for the dad joke API.
/// </summary>
/// <param name="scenarioContext">
///     ScenarioContext is a dictionary that can be used to share data between steps in a scenario
/// </param>
/// <param name="httpClient">
///     HttpClient is injected into the constructor by SpecFlow using the setup in ApplicationHooks.cs.
/// </param>
[Binding]
public sealed class JokeStepDefinitions(
    
    ScenarioContext scenarioContext,
    HttpClient httpClient)
{
    [Given(@"a joke already exists")]
    public async Task GivenAJokeAlreadyExists()
    {
        var joke = new CreateDadJokeRequest(
            "Why did the scarecrow win an award?",
            "Because he was outstanding in his field.");
        await SendPostRequest(joke);
    }

    [When(@"the endpoint for a random joke is called")]
    public async Task WhenTheEndpointForARandomJokeIsCalled()
    {
        var joke = await httpClient.GetFromJsonAsync<DadJoke>("/");
        scenarioContext.Add(Keys.Joke, joke);
    }

    [Then(@"a joke should be returned")]
    public void ThenAJokeShouldBeReturned()
    {
        var joke = scenarioContext.Get<CreateDadJokeRequest>(Keys.Joke);
        joke.ShouldNotBeNull();
    }

    private async Task SendPostRequest(CreateDadJokeRequest request)
    {
        var response = await httpClient.PostAsJsonAsync("/", request);

        var isSuccess = response.IsSuccessStatusCode;
        // scenarioContext.Add(Keys.WasActionSuccessKey, isSuccess);
    }
}