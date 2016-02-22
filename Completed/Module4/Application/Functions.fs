module Functions

open Types
open System

let tryPromoteToVip (customer, spendings) =
    if spendings > 100M then { customer with IsVip = true }
    else customer

let getSpendingsByMonth customer = customer.Id |> Data.getSpendings

let getSpendings customer =
    let spending = customer
                    |> getSpendingsByMonth
                    |> List.average
    (customer, spending)

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