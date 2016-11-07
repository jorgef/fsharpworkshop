#load "Types.fs"
#load "Functions.fs"

open System
open Types
open Functions

let customer = {
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

let vipCustomer = tryPromoteToVip (customer, 101M)

let purchases = getPurchases customer

let customerWithMoreCredit = customer |> increaseCredit vipCondition

let upgradedCustomer = upgradeCustomer customer