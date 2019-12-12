module groupBy

// groups a sequence by result of function
// function might get an element property
// or do some calculation

// returns key/value pairs, keys are distinct
// each value is a sequence of matching elements of that key

open System
open System.IO

let LengthClass length =
    if length < 1024L then "Small"
    else if length < 1024L * 1024L then "Medium"
    else "Large"

let FileSizeGroups dirName =
    dirName
    |> System.IO.Directory.EnumerateFiles
    |> Seq.map (fun name ->
        let info = new FileInfo(name)
        (name, info.Length))
    |> Seq.groupBy (fun (name, length) -> LengthClass length)

