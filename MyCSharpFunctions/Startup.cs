using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;

[assembly: FunctionsStartup(typeof(MyCSharpFunctions.Startup))]

namespace MyCSharpFunctions;

public sealed class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddHttpClient("MyAuthorizedClient", client =>
        {
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", "<token>");
        });
    }
}