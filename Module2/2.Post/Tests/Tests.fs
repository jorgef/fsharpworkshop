module Tests

open Xunit
open Swensen.Unquote
open Types
open Functions

[<Fact>]
let ``2-1 Increase min credit using id``() =
    let customer = { Id = 1; IsVip = false; Credit = 0.0 }
    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
    test <@ upgradedCustomer.Credit = 50.0  @>

[<Fact>]
let ``2-2 Increase max credit using id``() =
    let customer = { Id = 2; IsVip = false; Credit = 0.0 }
    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
    test <@ upgradedCustomer.Credit = 100.0  @>

[<Fact>]
let ``2-3 Increase credit keeping existing one``() =
    let customer = { Id = 2; IsVip = false; Credit = 10.0 }
    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
    test <@ upgradedCustomer.Credit = 110.0  @>

[<Fact>]
let ``2-4 Vip condition using non-vip customer``() =
    let customer = { Id = 2; IsVip = false; Credit = 0.0 }
    test <@ not (customer |> vipCondition) @>

[<Fact>]
let ``2-5 Vip condition using vip customer``() =
    let customer = { Id = 2; IsVip = true; Credit = 0.0 }
    test <@ customer |> vipCondition @>

[<Fact>]
let ``2-6 Increase max credit using vip``() =
    let customer = { Id = 2; IsVip = true; Credit = 0.0 }
    let upgradedCustomer = increaseCreditUsingVip customer
    test <@ upgradedCustomer.Credit = 100.0  @>

[<Fact>]
let ``2-7 Upgrade customer with high spendings``() =
    let customer = { Id = 2; IsVip = false; Credit = 0.0 }
    let upgradedCustomer = upgradeCustomer customer
    test <@ upgradedCustomer.IsVip = true && upgradedCustomer.Credit = 100.0 @>

[<Fact>]
let ``2-8 Upgrade customer with low spendings``() =
    let customer = { Id = 1; IsVip = false; Credit = 0.0 }
    let upgradedCustomer = upgradeCustomer customer
    test <@ upgradedCustomer.IsVip = false && upgradedCustomer.Credit = 50.0 @>