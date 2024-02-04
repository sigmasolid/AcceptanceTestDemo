using DadJoke.WebApi.Controllers;
using BoDi;
using DadJoke.Domain.Services;
using TechTalk.SpecFlow;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

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
        var dadJokeService = new DadJokeService(new InMemoryDadJokeRepository());
        var homeController = new HomeController(dadJokeService);
        objectContainer.RegisterInstanceAs(homeController);
    }
}