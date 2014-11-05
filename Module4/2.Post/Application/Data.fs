module Data

open Types
open FSharp.Data

type Json = JsonProvider<"Data.json">

let getSpendings id =
    Json.Load "Data.json"
    |> Seq.filter (fun c -> c.Id = id)
    |> Seq.collect (fun c -> c.Spendings 
                             |> Seq.map float)
    |> List.ofSeq

[<Literal>]
let cs = "Data Source=.;Initial Catalog=FSharpIntro;Integrated Security=SSPI;"

type SelectCustomers = 
    SqlCommandProvider<"SELECT Id, IsVip, Credit FROM dbo.Customers", cs>

let getCustomers () = 
    let cmd = new SelectCustomers ()
    cmd.Execute ()
    |> Seq.map (fun c -> 
        { Id = c.Id
          IsVip = c.IsVip
          Credit = c.Credit * 1.0<USD>
          PersonalDetails = None
          Notifications = NoNotifications })

type UpdateCustomer = 
    SqlCommandProvider<"UPDATE dbo.Customers SET IsVip = @IsVip, Credit = @Credit WHERE Id = @Id", cs>

let updateCustomer customer =
    let cmd = new UpdateCustomer ()
    cmd.Execute (customer.IsVip, (customer.Credit / 1.0<USD>), customer.Id)
