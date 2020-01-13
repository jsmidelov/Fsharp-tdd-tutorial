module findIndex

// Works like Seq.find and Seq.tryFind
// Returns index of the matching element

let StepsToPrime() =
    let rnd = new System.Random()

    let IsPrime n =
        let rec check i =
            i > n/2 || (n % i <> 0 && check (i+1))
        check 2

    let numbers = Seq.initInfinite(fun _ -> rnd.Next())

    let steps =
        numbers
        |> Seq.findIndex (fun n ->
            printfn "Trying %i" n
            IsPrime n)  
    steps+1

