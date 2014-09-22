namespace Services

open Types

type CustomerService() =

    member this.GetCustomers () = Data.getCustomers ()

    member this.UpgradeCustomers (ids: int seq) =
        match ids with
        | null -> ()
        | _ ->
            let customers = Data.getCustomers ()
            ids 
            |> Seq.map (fun id -> customers 
                                   |> Seq.find (fun c -> c.Id = id))
            |> Seq.map (Functions.upgradeCustomer >> Data.updateCustomer)
            |> List.ofSeq
            |> ignore

