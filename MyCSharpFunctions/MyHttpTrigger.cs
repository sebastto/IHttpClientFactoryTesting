using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyCSharpFunctions;

public sealed class MyHttpTrigger
{
    private readonly IHttpClientFactory _httpClientFactory;

    public MyHttpTrigger(IHttpClientFactory httpContextFactory)
    {
        _httpClientFactory = httpContextFactory;
    }

    [FunctionName("Function1")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req, ILogger log)
    {
        var authorizedClient = _httpClientFactory.CreateClient("MyAuthorizedClient");

        return new OkObjectResult("Ok");
    }   
}
