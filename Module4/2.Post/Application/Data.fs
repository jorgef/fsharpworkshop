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

type Csv = CsvProvider<"Data.csv">

let getCustomers () = 
    let file = Csv.Load "Data.csv"
    file.Rows
    |> Seq.map (fun c -> 
        { Id = c.Id
          IsVip = c.IsVip
          Credit = float c.Credit * 1.0<USD>
          PersonalDetails = None
          Notifications = NoNotifications })