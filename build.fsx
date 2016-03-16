// include Fake lib
#r @"packages/FAKE/tools/FakeLib.dll"

open Fake

open System
open System.IO

let buildDir = @"./build/"

Target "Clean" (fun _ ->
    CleanDirs [ buildDir ] 
)

Target "Build" (fun _ -> 
    !! @".\OwinSample.Host.sln"
        |> MSBuildRelease buildDir "Build"
        |> Log "Build-Output: "
)

//Deps
"Clean"
    ==> "Build"


// start build
RunTargetOrDefault "Build"