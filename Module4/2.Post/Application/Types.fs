module Types

open System

type PersonalDetails = 
    { FirstName: string
      LastName: string
      DateOfBirth: DateTime }

[<Measure>] type AUD
[<Measure>] type USD

type Notifications =
| NoNotifications
| ReceiveNotifications of receiveDeals: bool * receiveAlerts: bool

type Customer = 
    { Id: int
      IsVip: bool
      Credit: float<USD>
      PersonalDetails: PersonalDetails option
      Notifications: Notifications }
