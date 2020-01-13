module Find1
    // find takes a sequence and a boolean func as inputs.
    // Returns first element, or error if no element applies.
    // I.e. Seq.find is like LINQ's First(), and
    // Seq.TryFind is like LINQ's FirstOrDefault()
//open WithEnumerate;
// due to issues with opening my own files, I'm copying over the relevant parts for now
open System.IO

let SimpleFileHierarchy startDir =
    Directory.EnumerateFiles(startDir, @"*.*", System.IO.SearchOption.AllDirectories)

let rec SafeFileHierarchy startDir =
    let TryEnumerateFiles dir =
        try
            System.IO.Directory.EnumerateFiles(startDir)
        with _ -> Seq.empty
    let TryEnumerateDirs dir =
        try
            System.IO.Directory.EnumerateDirectories(startDir)
        with _ -> Seq.empty
    seq {
        yield! TryEnumerateFiles startDir
        for dir in TryEnumerateDirs startDir do
            yield! (SafeFileHierarchy dir)
    }

//  here begins the content
let longFileName =
    SafeFileHierarchy @"c:\temp"
    |> Seq.tryFind(fun name -> name.Length > 200)