#r @"..\..\packages\FSharp.Data\lib\net40\FSharp.Data.dll"

#load "Types.fs"
#load "Data.fs"
#load "Functions.fs"

open System
open Types
open Functions

let customer1 = { 
   Id = 1 
   IsVip = false 
   Credit = 0M<USD>
   PersonalDetails = Some { 
       FirstName = "John"
       LastName = "Doe"
       DateOfBirth = DateTime(1970, 11, 23) 
   }
   Notifications = ReceiveNotifications(receiveDeals = true, receiveAlerts = true) 
}

let customer2 = {
   Id = 2 
   IsVip = false 
   Credit = 10M<USD>
   PersonalDetails = None
   Notifications = NoNotifications 
}

let vipCustomer1 = tryPromoteToVip (customer1, 101M) 
let nonVipCustomer2 = tryPromoteToVip (customer2, 99M) 

let customer1Spendings = getSpendings customer1
let customer2Spendings = getSpendings customer2

let customer1WithMoreCredit = customer1 |> increaseCredit vipCondition
let customer2WithMoreCredit = customer2 |> increaseCredit vipCondition

let result = increaseCredit vipCondition

let upgradedCustomer1 = upgradeCustomer customer1
let upgradedCustoemr2 = upgradeCustomer customer2

let isAdultCustomer1 = isAdult customer1
let isAdultCustomer2 = isAdult customer2

let alertCustomer1 = getAlert customer1
let alertCustomer2 = getAlert customer2