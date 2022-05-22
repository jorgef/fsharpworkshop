﻿module Functions

open Types
open System

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer

let getPurchases customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)

let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100M<USD> }
    else { customer with Credit = customer.Credit + 50M<USD> }

let increaseCreditUsingVip = increaseCredit (fun c -> c.IsVip)

let upgradeCustomer = getPurchases >> tryPromoteToVip >> increaseCreditUsingVip

let isAdult customer =
    match customer.PersonalDetails with
    | None -> false
    | Some d -> d.DateOfBirth.AddYears 18 <= DateTime.Now.Date

let getAlert customer =
    match customer.Notifications  with
    | ReceiveNotifications(receiveAlerts = true) ->
        sprintf "Alert for customer %i" customer.Id
    | _ -> ""

let getCustomer id =
    let customers = [
        { Id = 1; IsVip = false; Credit = 0m<USD>; PersonalDetails = Some { FirstName = "John"; LastName = "Doe"; DateOfBirth = DateTime(1980, 1, 1) }; Notifications = NoNotifications }
        { Id = 2; IsVip = false; Credit = 10m<USD>; PersonalDetails = None; Notifications = ReceiveNotifications(true, true) }
        { Id = 3; IsVip = false; Credit = 30m<USD>; PersonalDetails = Some { FirstName = "Jane"; LastName = "Jones"; DateOfBirth = DateTime(2010, 2, 2) }; Notifications = ReceiveNotifications(true, false) }
        { Id = 4; IsVip = true;  Credit = 50m<USD>; PersonalDetails = Some { FirstName = "Joe"; LastName = "Smith"; DateOfBirth = DateTime(1986, 3, 3) }; Notifications = ReceiveNotifications(false, true) }
    ]
    customers
    |> List.find (fun c -> c.Id = id)