namespace MyFSharpFunctions

open Microsoft.Azure.Functions.Extensions.DependencyInjection
open Microsoft.Extensions.DependencyInjection
open System.Net.Http.Headers

type Startup () = 
    inherit FunctionsStartup()  
        override this.Configure (builder: IFunctionsHostBuilder ) =  
            builder.Services.AddHttpClient("MyAuthorizedClient", (fun c -> 
                c.DefaultRequestHeaders.Authorization <- AuthenticationHeaderValue("Bearer", "<token>")
            )) |> ignore

[<assembly: FunctionsStartup(typeof<Startup>)>]
do ()