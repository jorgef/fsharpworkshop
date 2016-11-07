module Functions

open Types
open System

let tryPromoteToVip (customer, purchases) =
    if purchases > 100M then { customer with IsVip = true }
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
    | ReceiveNotifications(receiveDeals = _; receiveAlerts = true) ->
        Some (sprintf "Alert for customer: %i" customer.Id)
    | _ -> None

let getCustomer id =
    let customers = [
        { Id = 1; IsVip = false; Credit = 0m<USD>; PersonalDetails = None; Notifications = NoNotifications }
        { Id = 2; IsVip = false; Credit = 10m<USD>; PersonalDetails = None; Notifications = NoNotifications }
        { Id = 3; IsVip = false; Credit = 30m<USD>; PersonalDetails = None; Notifications = NoNotifications }
        { Id = 4; IsVip = true;  Credit = 50m<USD>; PersonalDetails = None; Notifications = NoNotifications }
    ]
    customers
    |> List.find (fun c -> c.Id = id)