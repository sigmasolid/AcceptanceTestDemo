using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace DadJoke.WebApi.AcceptanceTests.Hooks;

public class WebApplicationToTest : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        var acceptanceTestConnectionString =
            "Server=Provider=PostgreSQL OLE DB Provider;Data Source=localhost,5432;location=myDataBase;User ID=myUsername;password=mysecretpassword;timeout=1000;";
        _ = builder.ConfigureTestServices(services =>
        {
            //services.AddTransient<Interface, ImplementationFake>();
            builder.UseSetting("ConnectionStrings:MyConnectionString", acceptanceTestConnectionString);
        });
    }
}