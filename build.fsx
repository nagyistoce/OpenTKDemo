#r @"packages/FAKE/tools/FakeLib.dll"

open Fake

let resultsDir = "release"

Target "Clean" (fun _ ->
    DeleteDirs [resultsDir]
)

Target "Build" (fun _ ->
    !! "/**/*.*proj"
    |> MSBuildRelease resultsDir "Build"
    |> Log "Build-Output: "
)

Target "Default" DoNothing

"Clean"
    ==> "Build"
    ==> "Default"

RunTargetOrDefault "Default"