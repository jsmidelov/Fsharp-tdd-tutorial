module Distinct

// Takes a sequence, returns its unique elements
// Elements must support equality, meaning they do not have the "noEquality"-constraint applied

open System.IO

let Extensions (dir: string) =
    Directory.EnumerateFiles(dir)
    |> Seq.map (fun name -> Path.GetExtension(name))
    |> Seq.distinct

type Vegetable =
    { Name : string
      Color : string }

let availableVegetables =
    [| {Name = "Carrot"
        Color = "orange"};
       {Name = "Peas"
        Color = "green"};
       {Name = "Lettuce"
        Color = "green"};
       {Name = "Beetroot"
        Color = "purple"};
       {Name = "Aubergine"
        Color = "purple"};
       {Name = "Potato"
        Color = "white"};
       {Name = "Swede"
        Color = "orange"};
       {Name = "Turnip"
        Color = "white"};
       {Name = "Cabbage"
        Color = "green"};
    |]

let Randomize s =
    let r = new System.Random()
    s |> Seq.sortBy (fun _ -> r.Next())

let Menu() =
    availableVegetables
    |> Randomize
    |> Seq.distinctBy(fun v -> v.Color)