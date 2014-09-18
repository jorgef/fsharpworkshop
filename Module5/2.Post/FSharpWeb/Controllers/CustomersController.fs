namespace FSharpWeb.Controllers

open System.Web.Mvc
open Services

type CustomersController() =
    inherit Controller()

    let service = CustomerService()
    
    member x.Index () = 
        x.View(service.GetCustomers ())

    member x.Post (ids: int seq) = 
        service.UpgradeCustomers(ids);
        x.RedirectToAction("Index")


