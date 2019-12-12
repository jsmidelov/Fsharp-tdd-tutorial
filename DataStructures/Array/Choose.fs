module Choose

open System.Net

// mapping valid values, filtering them, and extracting the stuff we want from them is surprisingly common. Thus "choose" exists as a short-hand
let GetRequest() =
    let requests = [|
        "http://www.google.com";
        "http://www.pluralsight.com";
        "http://99.99.99.99/DoesNotExist";
    |]
    use wc = new WebClient()

    requests
    |> Array.choose (fun url ->
        try
            wc.DownloadString(url) |> Some
        with
        | _ -> None)
    |> Array.iter(fun s -> printfn "Content: %s" (s.Trim().Substring(0,100)))