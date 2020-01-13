module init

// from a range expression
let integers1 = [1..1000]

// from a list expression
let integers2 = [for i in 1..1000 do yield i]
let integers3 = [for i in 1..1000 -> i]

// using a function in the List module
let integers4 = List.init 1000 (fun i -> i+1)

// from another other collection
let Files (dir:string) =
    System.IO.Directory.EnumerateFiles(dir)
    |> List.ofSeq

// only difference is you use a regular [] rather than [||]

// only missing is a List.unfold, but can be done this way
let myUnfoldList =
    Seq.unfold(fun state ->
        if state > 100 then None
        else Some(state,state+1)
    ) 0 |> List.ofSeq
// although there is no unfold, you can have a recursive expression
let rec myListRecusive n =
    [
        if n > 100 then
            yield n
            yield! (myListRecusive (n+1))
    ]

 // square brackets can also be used as equivalent to the seq {} expression