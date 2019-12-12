module Mapi

// .mapi
let VowelPositionsMap (str:string) =
    let vowels = "aeiouåäöAEIOUÅÄÖ"
    str.ToCharArray()
    |> Array.mapi(fun i c -> if vowels.Contains(c.ToString()) then
                                sprintf "Vowel at position: %i %c" i c
                             else
                                "Some other character");