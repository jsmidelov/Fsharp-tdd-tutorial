module IsNoneAndIsSome

open System.Net

let GetRequest() =
    let requests = [|
        "http://www.google.com";
        "http://www.pluralsight.com";
        "http://99.99.99.99/DoesNotExist";
    |]
    use wc = new WebClient()

    requests
    |> Array.map (fun url ->
        try
            wc.DownloadString(url) |> Some
        with
        | _ -> None)
    |> Array.filter (fun s -> s.IsSome)
    |> Array.map(fun s -> s.Value)
    |> Array.iter(fun s -> printfn "Content: %s" (s.Trim().Substring(0,100)))