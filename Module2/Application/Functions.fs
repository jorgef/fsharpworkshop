module Functions

open Types

let tryPromoteToVip purchases =
    let customer, amount = purchases
    if amount > 100M then { customer with IsVip = true }
    else customer

let getPurchases customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)

let increaseCredit condition customer =
    if condition customer then { customer with Credit = customer.Credit + 100M}
    else { customer with Credit = customer.Credit + 50M }

let increaseCreditUsingVip = increaseCredit (fun c -> c.IsVip)

// Upgrade customer using variables to store the intermidaite values
let upgradeCustomerUsingVars customer =
    let customerWithPurchases = getPurchases customer
    let promotedCustomer = tryPromoteToVip customerWithPurchases
    let upgradedCustomer = increaseCreditUsingVip promotedCustomer
    upgradedCustomer

// Upgrade cusomer using piplining operator, i.e...pass the return value from each function and pass it to the next function
let upgradeCustomerPipelining customer =
    customer
    |> getPurchases
    |> tryPromoteToVip
    |> increaseCreditUsingVip

// Upgrade customer using composition, it is missing the customer varirables but it is passed into the getPurchases which the result of that is then passed to tryPromoteToVip then value of that pass to increaseCreditUsingVip.
let upgradeCustomer = getPurchases >> tryPromoteToVip >> increaseCreditUsingVip