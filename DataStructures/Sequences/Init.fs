module Init

open System.IO
// a major diff between array and sequence is the latter does not evaluate a value until called
let integers = {1..1000}
let byExpression = seq {for i in 1..1000 do yield i}
let byShortHandExpr = seq {for i in 1..1000 -> i}

let byFunction = Seq.init 1000 (fun i -> i+1)
let byInfiFun = Seq.initInfinite (fun i -> i+1)

let extensions (dir:string) =
    Directory.EnumerateFiles(dir)
    |> Seq.map (fun name -> Path.GetExtension(name))
    |> Seq.distinct

