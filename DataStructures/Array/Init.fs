module Init

open System

// initialize arrays
let init1 = [|1;2;3|];
let init2 = [|10..20|];
let init3 = [|10..2..20|]
let init4 = [|for i in 10..20 do if i%2=0 then yield i|]

let lastDays year = [|
    for i in 1..12 do
        let firstDay = DateTime(year, i ,i)
        let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year,i)-1))
        yield lastDay
|]