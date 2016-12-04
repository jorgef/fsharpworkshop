module Program

open System
open Services
open Functions

[<EntryPoint>]
let rec main args =
    let service = CustomerService()
    printf "Id to upgrade [1-4]: "
    let valid, id = Int32.TryParse <| Console.ReadLine ()
    printfn ""
    if not valid then
        printfn "Invalid customer Id"
    else
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
    printfn "Press any key to try again or 'q' to quit"
    let input = Console.ReadKey()
    printfn ""
    if input.Key = ConsoleKey.Q then 0 else main args