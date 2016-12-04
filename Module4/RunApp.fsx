#r "../packages/FAKE/tools/FakeLib.dll"
open Fake 
open Fake.Testing 

let appDir   = "./appOutput/"
let appReferences = !! "/Application/*.fsproj"

Target "BuildApp" (fun _ ->
    MSBuildDebug appDir "Build" appReferences
        |> Log "BuildApp-Output: "
)

Target "RunApp" (fun _ ->
    let result =
        ExecProcess (fun info -> 
            let fileName = "Application.exe"
            let appPath = if EnvironmentHelper.isMono then fileName else appDir + fileName 
            info.FileName <- appPath
            info.WorkingDirectory <- appDir
        ) System.TimeSpan.MaxValue

    if result <> 0 then failwith "Application Failed"
)

"BuildApp"
==> "RunApp"

Run "RunApp"