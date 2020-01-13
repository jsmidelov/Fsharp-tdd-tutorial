module WithEnumerate
    open System.IO

    // using reference
    let seqWithRef =
        seq {
            let i = ref 0
            while !i < 100 do
                yield !i
                i := !i+1
        }

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
