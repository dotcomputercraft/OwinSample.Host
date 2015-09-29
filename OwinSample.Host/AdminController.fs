namespace OwinSample.Host

open System
open Microsoft.Owin
open Owin
open System.Web.Http
open HttpResponseHelpers

[<RoutePrefix("api/admin")>]
type AdminController() =
    inherit ApiController()

    [<HttpGet; Route("hello")>]
    member x.Hello() =
        let value = sprintf "I'm running on %A" Environment.OSVersion
        value |> okWithStringContent "text/plain"
