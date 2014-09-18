module Tests

open Xunit
open Swensen.Unquote
open Types
open Functions

[<Fact>]
let ``1-1 Create customer``() =
    let customer = { Id = 1; IsVip = false; Credit = 0.0 }
    test <@ customer.GetType () = typeof<Customer> @>

[<Fact>]
let ``1-2 Promote to vip``() =
    let customer = { Id = 1; IsVip = false; Credit = 0.0 }
    let promotedCustomer = tryPromoteToVip (customer, 100.1)
    test <@ promotedCustomer.IsVip = true  @>

[<Fact>]
let ``1-3 Do not promote to vip``() =
    let customer = { Id = 1; IsVip = false; Credit = 0.0 }
    let promotedCustomer = tryPromoteToVip (customer, 99.9)
    test <@ promotedCustomer.IsVip = false  @>

[<Fact>]
let ``1-4 Get spendings for even customers``() =
    let customer = { Id = 1; IsVip = false; Credit = 0.0 }
    let _, spendings = getSpendings customer
    test <@ spendings = 80.0  @>

[<Fact>]
let ``1-5 Get spendings for odd customers``() =
    let customer = { Id = 2; IsVip = false; Credit = 0.0 }
    let _, spendings = getSpendings customer
    test <@ spendings = 120.0  @>