module Functions

open Types

// This create a function called tryPromoteToVip which takes a parameter called purchases which is a tuple that is a customer and a decimal.
let tryPromoteToVip purchases = 
    // Destructure the values from purchases tuple
    let customer, amount = purchases
    // Check if the amount is greater than 100M return a copy of the customer with isVip set to true
    if amount > 100M then { customer with IsVip = true}
    // else just return the customer
    else customer

let getPurchases customer =
    if customer.Id % 2 = 0 then (customer, 120M)
    else (customer, 80M)