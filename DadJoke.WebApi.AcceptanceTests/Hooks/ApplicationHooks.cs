using System.Net;
using DadJoke.WebApi.Controllers;
using BoDi;
using DadJoke.Domain.Services;
using Ductus.FluentDocker.Builders;
using Ductus.FluentDocker.Services;
using TechTalk.SpecFlow;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

[Binding]
public class ApplicationHooks(ObjectContainer objectContainer)
{
    private static ICompositeService _compositeService = null!;
    private const string DockerComposeFileName = "docker-compose.yml";
    private const string BaseAddress = "http://localhost:5555";
    
    [BeforeTestRun]
    public static void DockerComposeUp()
    {
        var dockerComposePath = GetDockerComposeLocation();

        var confirmationUrl = BaseAddress;
        _compositeService = new Builder()
            .UseContainer()
            .UseCompose()
            .FromFile(dockerComposePath)
            .RemoveOrphans()
            .WaitForHttp("dadjoke.webapi", $"{confirmationUrl}/health",
                continuation: (response, _) => response.Code != HttpStatusCode.OK ? 2000 : 0)
            .Build().Start();
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
        // var dadJokeService = new DadJokeService(new InMemoryDadJokeRepository());
        // var homeController = new HomeController(dadJokeService);
        // objectContainer.RegisterInstanceAs(homeController);
    }

    [AfterTestRun]
    public static void DockerComposeDown()
    {
        _compositeService.Stop();
        _compositeService.Dispose();
    }

    private static string GetDockerComposeLocation()
    {
        var directory = Directory.GetCurrentDirectory();
        while (!Directory.EnumerateFiles(directory, "*.yml").Any(s => s.EndsWith(DockerComposeFileName)))
        {
            directory = directory.Substring(0, directory.LastIndexOf(Path.DirectorySeparatorChar));
        }

        return Path.Combine(directory, DockerComposeFileName);
    }
}