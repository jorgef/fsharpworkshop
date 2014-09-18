module Data

open Types

open System
open System.Linq

open FSharp.Data
open FSharp.Data.Sql
open FSharp.Data.Sql.Common

type db = SqlDataProvider<ConnectionString = "Data Source=.;
                                              Initial Catalog=FSharpIntro;
                                              Integrated Security=SSPI;",
                          DatabaseVendor = DatabaseProviderTypes.MSSQLSERVER,
                          IndividualsAmount = 1000,
                          UseOptionTypes = true>

let getCustomers () = 
    let ctx = db.GetDataContext()
    ctx.``[dbo].[Customers]``
    |> Seq.map (fun c -> 
                        { Id = c.Id
                          IsVip = c.IsVip
                          Credit = c.Credit * 1.0<USD>
                          PersonalDetails = None
                          Notifications = NoNotifications })

let updateCustomer customer = 
    let ctx = db.GetDataContext()
    let dbCustomer = query { for c in ctx.``[dbo].[Customers]`` do
                             where (c.Id = customer.Id)
                             select c }
                  |> Seq.exactlyOne
    dbCustomer.IsVip <- customer.IsVip
    dbCustomer.Credit <- customer.Credit / 1.0<USD> 
    ctx.SubmitUpdates ()


type json = JsonProvider<"Data.json">

let getSpendings id =
    json.Load("App_Data\Data.json")
    |> Seq.filter (fun c -> c.Id = id)
    |> Seq.collect (fun c -> c.Spendings 
                             |> Seq.map (fun s -> float(s)))
    |> List.ofSeq


