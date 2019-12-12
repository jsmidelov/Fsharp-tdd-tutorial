module Sum

open System.Net

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
    |> Array.map(fun s -> s.Length)
    |> Array.sum

let GetRequestSumBy() =
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
    |> Array.sumBy(fun s -> s.Length)