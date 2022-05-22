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

let purchases = (customer, 101M)
let vipCustomer = tryPromoteToVip purchases

let calculatedPurchases = getPurchases customer

let customerWithMoreCredit = customer |> increaseCredit (fun c -> c.IsVip)

let upgradedCustomer = upgradeCustomer customer