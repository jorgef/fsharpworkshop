module Functions

open Types
open System

let tryPromoteToVip (customer, spendings) =
    if spendings > 100.0 then { customer with IsVip = true }
    else customer

let getSpendings customer =
    if customer.Id % 2 = 0 then (customer, 120.0)
    else (customer, 80.0)

let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100.0<USD> }
    else { customer with Credit = customer.Credit + 50.0<USD> }

let vipCondition customer = customer.IsVip

let increaseCreditUsingVip = increaseCredit vipCondition

let upgradeCustomer = getSpendings >> tryPromoteToVip >> increaseCreditUsingVip

let isAdult customer = 
    match customer.PersonalDetails with
    | None -> false
    | Some d -> d.DateOfBirth.AddYears 18 <= DateTime.Now.Date

let getAlert customer =
    match customer.Notifications  with
    | ReceiveNotifications(receiveDeals = _; receiveAlerts = true) -> 
        Some (sprintf "Alert for customer: %i" customer.Id)
    | _ -> None

