module JaggedArrays

let jagged1 = [| [|1;3;9|]; [|4;6|] |]
let jagged2 = Array.init 3 (fun x -> [|0..x|])

// access by using
printfn "%i" jagged1.[0].[2]

// type annotations are displayed as
// int [] []