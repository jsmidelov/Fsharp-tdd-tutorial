module Sort

open System.Net

let GetRequest() =
    let requests = [|
        "http://www.google.com";
        "http://www.pluralsight.com";
        "http://99.99.99.99/DoesNotExist";
        "http://www.bbc.co.uk";
        "http://www.amazon.com";
        "http://www.bing.com";
    |]
    use wc = new WebClient()

    requests
    |> Array.choose (fun url ->
        try
            (url,wc.DownloadString(url).Length) |> Some
        with
        | _ -> None)
    |> Array.sortBy(fun (url, length) -> -length)
