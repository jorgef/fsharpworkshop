//module Program
//
//open System
//open Services
//open Types
//
//let printCustomer c = printfn "Id: %A, IsVip: %b, Credit: %A" c.Id c.IsVip c.Credit
//
//[<EntryPoint>]
//let rec main args =
//    let service = CustomerService()
//    service.GetCustomers () 
//    |> Seq.iter printCustomer
//    printf "Id to upgrade: "
//    let id = int (Console.ReadLine ())
//    printfn ""
//    let customer = service.UpgradeCustomer id
//    customer |> printCustomer
//    printfn ""
//    printfn "Press enter to try again"
//    Console.ReadLine () |> ignore
//    main args
