using System.Net;
using DadJoke.WebApi.Controllers;
using BoDi;
using DadJoke.Domain.Services;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

[Binding]
public class ApplicationHooks(ObjectContainer objectContainer)
{
    private static ICompositeService _compositeService = null!;
    private const string DockerComposeFileName = "docker-compose.yml";
    private const string BaseAddress = "http://localhost:5555";
    
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // Do stuff before the test run (ie. before any scenarios are run)
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri(BaseAddress)
        };
        // ObjectContainer is a dependency injection container provided by SpecFlow
        objectContainer.RegisterInstanceAs(httpClient);
        objectContainer.RegisterInstanceAs(new WebApplicationToTest());
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        // Clean up after the test run (ie. after all scenarios are run)
    }
}