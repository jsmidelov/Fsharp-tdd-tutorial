module windowed

// Takes a sequence and a window length (l)
// Returns a sequence of arrays of that length
// Each array holds elements from i to (i+l)-1
// Until the last element has n as last element
// like panning a window along a rule

let routeHeights = [|552;398;402;399;481;512;392;350|]

let Peaks heights =
    heights
    |> Seq.windowed 3
    |> Seq.choose(fun triplet ->
        match triplet with
        | [|a;b;c|] when b>a && b>c -> Some b
        | _ -> None)