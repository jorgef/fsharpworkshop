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