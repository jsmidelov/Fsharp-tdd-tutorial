// seq.pick iterates through the array, and returns first non-None value.
// Throws error if none returns None, so use TryPick
module Pick

open System
open System.Net

let randomRealUrl() =
    let rnd = System.Random()

    let RandomUrl len =
        let RandAlpha() = rnd.Next(int('a'), int('z')+1) |> char
        let randChars = Array.init len (fun _ -> RandAlpha())
        let randString = new String(randChars)
        sprintf "http://www.%s.com" randString

    let urls = Seq.initInfinite(fun _ -> RandomUrl 5);

    use wc = new WebClient();

    let urls = Seq.initInfinite(fun _ -> RandomUrl 5)
    urls |> Seq.pick(fun url ->
        try
            printfn "Trying %s" url
            wc.DownloadString(url) |> ignore
            url |> Some
        with _ -> None)
