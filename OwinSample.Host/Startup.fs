module Startup

open Owin
open Microsoft.Owin
open System
open System.Net.Http
open System.Web
open System.Web.Http
open System.Web.Http.Owin
open Microsoft.Owin.Security.ActiveDirectory
open System.IdentityModel.Tokens
open System.Configuration
open System.Web.Http.Filters
open System.Net
open System.Web.Http.ExceptionHandling
open System.Threading.Tasks

[<Sealed>]
type Startup() =

    static member RegisterWebApi(config: HttpConfiguration) =
        // Configure routing
        config.MapHttpAttributeRoutes()

        // Configure serialization
        config.Formatters.XmlFormatter.UseXmlSerializer <- true
        config.Formatters.JsonFormatter.SerializerSettings.ContractResolver <- Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()

        // Additional Web API settings

    member __.Configuration(builder: IAppBuilder) =

        let config = new HttpConfiguration()
//        let filter = new ExceptionLoggingFilter(logger);
//        config.Filters.Add(filter);
        builder.Use(Func<IOwinContext,Func<Task>,_>(fun ctx next-> 
            printf "Request: %A" ctx.Request.Uri
            next.Invoke())) |> ignore
        Startup.RegisterWebApi(config)
    
        printfn "OSVerion - %A" Environment.OSVersion
        let isWindowsOS = Environment.OSVersion.ToString() |> (fun p -> p.Contains("Windows"))
        printfn "isWindowsOS - %b" isWindowsOS

        builder.UseWebApi(config) |> ignore
        config.EnsureInitialized()
