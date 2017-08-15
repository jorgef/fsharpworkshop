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