using BoDi;
using TechTalk.SpecFlow;

namespace AcceptanceTestDemo.AcceptanceTests.Hooks;

[Binding]
public class ApplicationHooks(ObjectContainer objectContainer)
{
    
    [BeforeTestRun]
    public static void BeforeTest()
    {
        
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        var httpClient = new HttpClient()
        {
            BaseAddress = new Uri("http://localhost:5000")
        };
        // ObjectContainer is a dependency injection container provided by SpecFlow
        objectContainer.RegisterInstanceAs(httpClient);
    }
}