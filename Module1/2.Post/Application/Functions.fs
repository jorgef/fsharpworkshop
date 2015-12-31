module Functions

open Types

let tryPromoteToVip (customer, spendings) =
    if spendings > 100M then { customer with IsVip = true }
    else customer

let getSpendings customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)