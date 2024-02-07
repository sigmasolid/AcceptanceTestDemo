using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

public class WebApplicationToTest : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        //Environment.SetEnvironmentVariable("CacheSettings:UseCache", "false");

        _ = builder.ConfigureTestServices(services =>
        {
            //services.AddTransient<Interface, ImplementationFake>();
        });
    }
}