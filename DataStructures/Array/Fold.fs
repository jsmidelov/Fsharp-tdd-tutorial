module Fold

let PrintRow (separator: string) (arr: array<string>) =
    arr
    |> Array.fold (fun acc elem -> sprintf "%s%s%s" acc elem separator) separator