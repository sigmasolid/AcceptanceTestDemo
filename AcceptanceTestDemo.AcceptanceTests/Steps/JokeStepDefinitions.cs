using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace AcceptanceTestDemo.AcceptanceTests.Steps;

[Binding]
public sealed class JokeStepDefinitions(ScenarioContext scenarioContext)
{
    [Given(@"a joke already exists")]
    public void GivenAJokeAlreadyExists()
    {
    }

    [When(@"the endpoint for a random joke is called")]
    public void WhenTheEndpointForARandomJokeIsCalled()
    {
    }

    [Then(@"a joke should be returned")]
    public void ThenAJokeShouldBeReturned()
    {
    }
}