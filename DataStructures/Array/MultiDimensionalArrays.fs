module MultiDimensionalArrays

let my2D =
    Array2D.init 12 12
        (fun x y -> (x+1)*(y+1))

// accessed using
printfn "%i" my2D.[3,4]

// there are also Array3D and Array4D for even more dimensions

// type annotations are displayed as
// for 2D arrays: int [,]
// for 3D arrays: int [,,]