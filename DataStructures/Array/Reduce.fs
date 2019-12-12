module Reduce

open System

let ReduceDemo (arr: array<string>) =
    arr
    |> Array.reduce (fun acc elem -> sprintf "%s, %s" acc elem)