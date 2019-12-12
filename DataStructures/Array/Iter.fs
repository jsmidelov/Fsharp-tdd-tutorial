module Iter

// .iter
// does not return anything, thus being a non-pure functional method, as anything it does is by side-effect
let VowelPositionsIter (str:string) =
    let vowels = "aeiouåäöAEIOUÅÄÖ"
    str.ToCharArray()
    |> Array.iteri(fun i c -> if vowels.Contains(c.ToString()) then
                                printfn "Vowel at position: %i %c" i c);