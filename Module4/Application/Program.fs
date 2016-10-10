module Program
//
open System
//open Services
//open Types
//open Functions
//
//let printCustomer c = printfn "Id: %A, IsVip: %b, Credit: %A" c.Id c.IsVip c.Credit
//
[<EntryPoint>]
let rec main args =
//    let service = CustomerService()
//    printf "Id to upgrade [1-4]: "
//    let id = int (Console.ReadLine ())
//    printfn ""
//    let customerBefore = getCustomer id
//    customerBefore |> printCustomer
//    printfn "Upgrading customer..."
//    let customerAfter = service.UpgradeCustomer id
//    printfn "Customer upgraded"
//    customerAfter |> printCustomer
//    printfn ""
//    printfn "Press enter to try again"
    Console.ReadLine () |> ignore
    main args
