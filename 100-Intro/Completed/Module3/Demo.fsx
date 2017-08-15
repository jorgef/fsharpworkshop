// Demo 1

let a = 1
let b = 2
let sum x y = x + y
let res = sum a b

let myTuple = (42, "hello")
let number, message = myTuple

type MyRecord = { Number: int; Message: string }
let myRecord = { Number = 42; Message = "hello" }
let newRecord = { myRecord with Message = "hi" }


// Demo 2

let compute (x: int) (y: int) (operation: int -> int -> int) = operation x y
let res' = compute 1 2 sum

let addOne = sum 1
let addTwo = sum 2

let res1 = addOne 1
let res2 = addTwo res1

let res2' =
    1
    |> addOne
    |> addTwo

let addThree = addOne >> addTwo
let res2'' = addThree 1


// Demo 3

let divide x y =
    match y with
    | 0 -> None
    | _ -> Some(x/y)

let result = divide 4 2
let result' = divide 4 0

type DivisionResult =
| DivisionSuccess of result: int
| DivisionError of message: string

let divide' x y =
    match y with
    |0 -> DivisionError(message = "Divide by zero")
    |_ -> DivisionSuccess(result = x / y)

let result'' = divide' 4 2
let result''' = divide' 4 0

[<Measure>] type m; [<Measure>] type km; [<Measure>] type h
let distanceInMts = 11580.0<m>
let distanceInKms = 87.34<km>
//let totalDistance = distanceInMts + distanceInKms // Error

let convertToKms (mts: float<m>) =
    let m = mts / 1.0<m> // remove unit of measure
    let k = m / 1000.0   // convert
    k * 1.0<km>          // add new unit of measure

let convertToKms' (mts: float<m>) = mts / 1000.0<m> * 1.0<km>

let convertedToKms = convertToKms distanceInMts
let totalDistance' = convertedToKms + distanceInKms
let speed = totalDistance' / 2.4<h>