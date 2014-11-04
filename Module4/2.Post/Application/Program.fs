module Program

open System
open Services
open Types

[<EntryPoint>]
let rec main args =
    let service = CustomerService ()
    service.GetCustomers () 
    |> Seq.iter (fun c -> printfn "Id: %A, IsVip: %b, Credit: %A" c.Id c.IsVip c.Credit)
    printf "Id to upgrade: "
    let id = int (Console.ReadLine ())
    service.UpgradeCustomer id
    main args
