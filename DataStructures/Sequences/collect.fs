module collect

// Takes an input sequence
// ...and a function which produces a sequence of elements
// applies function to each input element
// concatenates results

let UniqueWords =
    let urls =
        [|"http://www.google.com"
          "http://www.pluralsight.com"
          "http://www.amazon.com"|]
    let words(s: string) =
        let re = new System.Text.RegularExpressions.Regex(@"\b\w+\b")
        let words = re.Matches(s)
        words
        |> Seq.cast
        |> Seq.map (fun w -> w.ToString())
    use wc = new System.Net.WebClient()
    urls
    |> Seq.choose(fun url ->
        try
            wc.DownloadString(url) |> Some
        with _ -> None)
    |> Seq.collect words
    |> Seq.distinct
    |> Seq.sort
    |> Seq.iter (fun w -> printfn "%s" w)