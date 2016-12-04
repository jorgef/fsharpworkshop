module Tests

open System
open Xunit
open Swensen.Unquote
open Types
open Functions
open Services

let customer = {
    Id = 1
    IsVip = false
    Credit = 0M<USD>
    PersonalDetails = Some {
        FirstName = "John"
        LastName = "Doe"
        DateOfBirth = DateTime(1970, 11, 23) }
    Notifications = ReceiveNotifications(receiveDeals = true,
                                         receiveAlerts = true) }


[<Fact>]
let ``4-1 Get purchases average``() =
    let purchases = getPurchases customer
    test <@ purchases = (customer, 60M) @>

[<Fact>]
let ``4-2 Upgrade customer``() =
    let service = CustomerService()
    let upgradedCustomer = service.UpgradeCustomer 2
    test <@ upgradedCustomer.IsVip @>
    test <@ upgradedCustomer.Credit = 110M<USD> @>

[<Fact>]
let ``4-3 Get customer info``() =
    let service = CustomerService()
    let info = service.GetCustomerInfo customer
    let expectedInfo = "Id: 1, IsVip: false, Credit: 0.00, IsAdult: true, Alert: Alert for customer 1"
    test <@ info = expectedInfo @>