module Program

open System
open Services
open Functions

[<EntryPoint>]
let rec main args =
    let service = CustomerService()
    printf "Id to upgrade [1-4]: "
    let id = int (Console.ReadLine ())
    printfn ""
    printfn "Customer to upgrade:"
    let customerBefore = getCustomer id
    customerBefore |> service.GetCustomerInfo |> printfn "%s"
    printfn ""
    printfn "Upgrading customer..."
    let customerAfter = service.UpgradeCustomer id
    printfn ""
    printfn "Customer upgraded:"
    customerAfter |> service.GetCustomerInfo |> printfn "%s"
    printfn ""
    printfn "Press enter to try again"
    Console.ReadLine () |> ignore
    main args