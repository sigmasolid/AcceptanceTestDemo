using DadJoke.Domain;
using DadJoke.WebApi.Controllers;
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
public sealed class JokeStepDefinitions(ScenarioContext scenarioContext,
    HomeController controller)
{
    [Given(@"a joke already exists")]
    public void GivenAJokeAlreadyExists()
    {
        var joke = new CreateDadJokeRequest(
            "Why did the scarecrow win an award?",
            "Because he was outstanding in his field.");
        controller.CreateJoke(joke);
    }

    [When(@"the endpoint for a random joke is called")]
    public void WhenTheEndpointForARandomJokeIsCalled()
    {
        var result = controller.GetRandomJoke();
        scenarioContext.Add("Joke", result.Value);
    }

    [Then(@"a joke should be returned")]
    public void ThenAJokeShouldBeReturned()
    {
        var joke = scenarioContext.Get<DadJoke.Domain.DadJoke>("Joke");
        joke.ShouldNotBeNull();
    }
}