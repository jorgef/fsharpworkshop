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

//[<Fact>]
//let ``4-1 Get spendings by month for customer 1``() =
//    let spendings = getSpendingsByMonth customer
//    test <@ spendings = List.init 12 (fun x -> 60M) @>
//
//[<Fact>]
//let ``4-2 Get spendings using getSpendingsByMonth``() =
//    let spendings = getSpendings customer
//    test <@ spendings = (customer, 60M) @>
//
//[<Fact>]
//let ``4-3 Get customers``() =
//    let service = CustomerService()
//    let customers = service.GetCustomers ()
//    test <@ Seq.length customers = 4 @>
//
//[<Fact>]
//let ``4-4 Update customer``() =
//    let service = CustomerService()
//    let upgradedCustomer = service.UpgradeCustomer 2
//    test <@ upgradedCustomer.IsVip @>
//    test <@ upgradedCustomer.Credit = 110M<USD> @>