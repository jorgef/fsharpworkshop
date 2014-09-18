module Data

open System
open Types

let customer1 = 
    { Id = 1 
      IsVip = false 
      Credit = 0.0<USD>
      PersonalDetails = Some { FirstName = "John"; 
                               LastName = "Doe"; 
                               DateOfBirth = DateTime(1970, 11, 23) }
      Notifications = ReceiveNotifications(receiveDeals = true, 
                                           receiveAlerts = true) }

let customer2 = 
    { Id = 2 
      IsVip = false 
      Credit = 10.0<USD>
      PersonalDetails = None
      Notifications = NoNotifications }


