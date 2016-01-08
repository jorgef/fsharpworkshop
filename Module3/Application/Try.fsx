#load "Types.fs"
#load "Functions.fs"

open Types
open Functions

let customer1 = { Id = 1; IsVip = false; Credit = 10M }
let customer2 = { Id = 2; IsVip = false; Credit = 0M }

let vipCustomer1 = tryPromoteToVip (customer1, 101M) 
let nonVipCustomer2 = tryPromoteToVip (customer2, 99M) 

let customer1Spendings = getSpendings customer1
let customer2Spendings = getSpendings customer2

let customer1WithMoreCredit = customer1 |> increaseCredit vipCondition
let customer2WithMoreCredit = customer2 |> increaseCredit vipCondition

let result = increaseCredit vipCondition

let upgradedCustomer1 = upgradeCustomer customer1
let upgradedCustoemr2 = upgradeCustomer customer2