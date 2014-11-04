namespace Services

type CustomerService() =

    member this.GetCustomers () = Data.getCustomers ()

    member this.UpgradeCustomer (id: int) =
            Data.getCustomers ()
            |> Seq.find (fun c -> c.Id = id)
            |> Functions.upgradeCustomer
            |> Data.updateCustomer
            |> ignore
