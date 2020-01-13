module Exists

// returns true if the function returns true for any element

let ContainsPrime numbers =
    let IsPrime n =
        let rec check i =
            i > n/2 || (n % i <> 0 && check (i+1))
        check 2
    numbers
    |> Seq.exists IsPrime

let TestContainsPrime() =
    let rnd = new System.Random()
    let numbers = [|8;9;12;13|]
    ContainsPrime numbers // returns 'true', as 13 is prime
