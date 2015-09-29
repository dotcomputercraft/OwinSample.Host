open Microsoft.Owin.Hosting;
open System;
open System.Collections.Generic;
open System.Linq;
open System.Text;
open System.Threading.Tasks;
open System.Threading

open Startup

// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv = 
    printfn "%A" argv

    let defaultEndpoint = "http://+:5000"
    let start (endpoint:string) = Microsoft.Owin.Hosting.WebApp.Start<Startup>(endpoint)

    printf "Starting Owin Self-Host Console"

    use ws = start defaultEndpoint

    Console.WriteLine("Owin.Host running Port 5000, to exit, press return.")
    //Console.ReadLine() |> ignore
    Thread.Sleep(Timeout.Infinite)

    0 // return an integer exit code
