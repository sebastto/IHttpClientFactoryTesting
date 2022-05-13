namespace MyFSharpFunctions

open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Extensions.Http
open Microsoft.Extensions.Logging
open System.Net.Http

type MyHttpTrigger(httpClientFactory: IHttpClientFactory) =
    let _httpClientFactory = httpClientFactory

    [<FunctionName("Function1")>]
    member self.Run 
        ([<HttpTrigger(AuthorizationLevel.Function, "get", Route = null)>] req: HttpRequest)
        (log: ILogger) =
        task {
            let factory = _httpClientFactory

            let authorizedClient = _httpClientFactory.CreateClient("MyAuthorizedClient")

            return OkObjectResult("Ok")
        }