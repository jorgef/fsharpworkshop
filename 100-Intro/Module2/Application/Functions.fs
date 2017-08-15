module Functions

open Types

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer

let getPurchases customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)