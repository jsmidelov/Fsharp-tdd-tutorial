module Zip


let ArrayMultiply (arr1:array<float>)(arr2:array<float>) =
    Array.zip arr1 arr2
    |> Array.map(fun (x1, x2) -> x1 * x2 )