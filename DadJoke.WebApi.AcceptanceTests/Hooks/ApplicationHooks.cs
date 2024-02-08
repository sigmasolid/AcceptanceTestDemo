using BoDi;
using TechTalk.SpecFlow;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

[Binding]
public class ApplicationHooks(ObjectContainer objectContainer)
{
    [BeforeTestRun]
    public static void BeforeTestRun()
    {
        // Do stuff before the test run (ie. before any scenarios are run)
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var webApplicationToTest = new WebApplicationToTest();
        var httpClient = webApplicationToTest.CreateClient();
        // ObjectContainer is a dependency injection container provided by SpecFlow
        objectContainer.RegisterInstanceAs(httpClient);
    }

    [AfterTestRun]
    public static void AfterTestRun()
    {
        // Clean up after the test run (ie. after all scenarios are run)
    }
}