#r "packages/FAKE/tools/FakeLib.dll"

open Fake 
open Fake.Testing 

EnvironmentHelper.setBuildParam "VisualStudioVersion" "14.0"
let testDir = "./testsOutput/"
let testDlls = !! (sprintf "%s/Tests.dll" testDir)
let testReferences = !! "./Tests/*.fsproj"

Target "BuildTests" (fun _ ->
    MSBuildDebug testDir "Build" testReferences
    |> Log "BuildTests-Output: "
)

Target "RunTests" (fun _ ->
    testDlls
    |> xUnit (fun p -> { p with ToolPath = @"../packages/xunit.runner.console/tools/xunit.console.exe" })
)

"BuildTests"
   ==> "RunTests"

Run "RunTests"