#r @"packages\FAKE.4.56.0\tools\fakelib.dll"
open System
open System.IO

// directories
let projdir = "."
let testsdir = "./automationtestssolution"
let screenobjectsdir = "./screenobjecthelpers"
let packagesdir = "./packages"

// url to download sourcetree
let sourcetreeurl = "https://downloads.atlassian.com/software/sourcetree/windows/beta/sourcetreesetup-2.0.14-beta-001.exe"
let localfilepath = "sourcetreesetup.exe"

target "downloadsourcetree" (fun _ ->
    let downloadsourcetree = execprocess (fun info ->
        info.filename <- @"curl" 
        info.workingdirectory <- projdir
        info.arguments <- (" -fss -o " + localfilepath + " " + sourcetreeurl)) (timespan.fromminutes 5.0)
)    
//    if downloadsourcetree <> 0 then 
//        failwithf ("download sourcetree returned with a non-zero exit code")
//    else
//        printfn "%s is now available" localfilepath

//target "automationsolutionproject" (fun _ ->
//    build setbuildparams "./sourcetreeautomation.sln"
//        |> donothing
//)

