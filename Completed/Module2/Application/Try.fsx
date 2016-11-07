#load "Types.fs"
#load "Functions.fs"

open Types
open Functions

let customer = { Id = 1; IsVip = false; Credit = 10M }

let vipCustomer = tryPromoteToVip (customer, 101M)

let purchases = getPurchases customer

let customerWithMoreCredit = increaseCredit (fun c -> c.IsVip) customer

let upgradedCustomer = upgradeCustomer customer