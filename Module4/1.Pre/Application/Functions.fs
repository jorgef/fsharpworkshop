module Functions

open Types
open System

let tryPromoteToVip (customer, spendings) =
    if spendings > 100M then { customer with IsVip = true }
    else customer

let getSpendings customer =
    // let weights = [0.8M; 0.9M; 1M; 0.7M; 0.9M; 1M; 0.8M; 1M; 1M; 1M; 0.8M; 0.7M]
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)

let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100M<USD> }
    else { customer with Credit = customer.Credit + 50M<USD> }

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