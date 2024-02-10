using BoDi;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using TechTalk.SpecFlow;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

[Binding]
public class ApplicationHooks(ObjectContainer objectContainer)
{
    private static IContainerService? _container;
    
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // Do stuff before the test run (ie. before any scenarios are run)

        // Example of starting a container
        _container =
            new Builder().UseContainer()
                .UseImage("kiasaki/alpine-postgres")
                .ExposePort(5432)
                .WithEnvironment("POSTGRES_PASSWORD=mysecretpassword")
                .WaitForPort("5432/tcp", 30000) // 30 seconds
                .Build()
                .Start();
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        // Do stuff before each scenario is run
        var webApplicationToTest = new WebApplicationToTest();
        var httpClient = webApplicationToTest.CreateClient();
        // ObjectContainer is a dependency injection container provided by SpecFlow
        objectContainer.RegisterInstanceAs(httpClient);
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        // Clean up after the test run (ie. after _all_ scenarios are completed)
        _container.Dispose();
    }
}