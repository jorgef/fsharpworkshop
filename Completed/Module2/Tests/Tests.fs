module Tests

open Xunit
open Swensen.Unquote
open Types
open Functions

[<Fact>]
let ``2-1 Increase min credit using id``() =
    let customer = { Id = 1; IsVip = false; Credit = 0M }
    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
    test <@ upgradedCustomer.Credit = 50M @>

[<Fact>]
let ``2-2 Increase max credit using id``() =
    let customer = { Id = 2; IsVip = false; Credit = 0M }
    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
    test <@ upgradedCustomer.Credit = 100M @>

[<Fact>]
let ``2-3 Increase credit keeping existing one``() =
    let customer = { Id = 2; IsVip = false; Credit = 10M }
    let upgradedCustomer = increaseCredit (fun c -> c.Id = 2) customer
    test <@ upgradedCustomer.Credit = 110M @>

[<Fact>]
let ``2-4 Increase max credit using vip``() =
    let customer = { Id = 2; IsVip = true; Credit = 0M }
    let upgradedCustomer = increaseCreditUsingVip customer
    test <@ upgradedCustomer.Credit = 100M @>

[<Fact>]
let ``2-5 Upgrade customer with even id``() =
    let customer = { Id = 2; IsVip = false; Credit = 0M }
    let upgradedCustomer = upgradeCustomer customer
    test <@ upgradedCustomer.IsVip = true && upgradedCustomer.Credit = 100M @>

[<Fact>]
let ``2-6 Upgrade customer with odd id``() =
    let customer = { Id = 1; IsVip = false; Credit = 0M }
    let upgradedCustomer = upgradeCustomer customer
    test <@ upgradedCustomer.IsVip = false && upgradedCustomer.Credit = 50M @>