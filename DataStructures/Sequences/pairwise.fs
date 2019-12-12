module pairwise

// Takes a sequence
// Returns tuples of i and i+1 element
// until n-1 and n

let routeHeights = [|552;398;402;399;481;512;392;350|]

let totalClimb heights =
    heights
    |> Seq.pairwise
    |> Seq.filter (fun (a,b) -> b > a)
    |> Seq.map (fun (a,b) -> b-a)
    |> Seq.sum