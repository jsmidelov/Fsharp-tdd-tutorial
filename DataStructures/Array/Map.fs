module Map

open System

// .map
let numbers = [|1..100|]
let squares =
    numbers
    |> Array.map(fun n -> n*n)

let fruits = [|"apples";"oranges";"pears"|]
let capitalFruits =
    fruits
    |> Array.map(fun fruit -> fruit.ToUpper() )

let InitCap str =
    if String.IsNullOrEmpty str then
        str
    else
        str.[0].ToString().ToUpperInvariant() + str.[1..];

let initCapFruits = fruits |> Array.map InitCap