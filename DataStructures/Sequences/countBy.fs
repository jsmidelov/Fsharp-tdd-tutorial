module countBy

// Works like groupBy, but value is the count for each distinct key
// Fn must support Equality
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

let VegColorCounts() =
    availableVegetables
    |> Seq.countBy (fun veg -> veg.Color)