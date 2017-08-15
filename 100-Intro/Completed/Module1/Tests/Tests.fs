module Tests

open Xunit
open Swensen.Unquote
open Types
open Functions

[<Fact>]
let ``1-1 Create customer``() =
    let customer = { Id = 1; IsVip = false; Credit = 0M }
    test <@ customer.GetType () = typeof<Customer> @>

[<Fact>]
let ``1-2 Promote to vip``() =
    let customer = { Id = 1; IsVip = false; Credit = 0M }
    let promotedCustomer = tryPromoteToVip (customer, 100.1M)
    test <@ promotedCustomer.IsVip = true @>

[<Fact>]
let ``1-3 Do not promote to vip``() =
    let customer = { Id = 1; IsVip = false; Credit = 0M }
    let promotedCustomer = tryPromoteToVip (customer, 99.9M)
    test <@ promotedCustomer.IsVip = false @>

[<Fact>]
let ``1-4 Get purchases for odd customers``() =
    let customer = { Id = 1; IsVip = false; Credit = 0M }
    let _, purchases = getPurchases customer
    test <@ purchases = 80M @>

[<Fact>]
let ``1-5 Get purchases for even customers``() =
    let customer = { Id = 2; IsVip = false; Credit = 0M }
    let _, purchases = getPurchases customer
    test <@ purchases = 120M @>