module Filter

open System

let lastDays year = [|
    for i in 1..12 do
        let firstDay = DateTime(year, i ,1)
        let lastDay = firstDay.AddDays(float(DateTime.DaysInMonth(year,i)-1))
        yield lastDay
|]

let IsWeekend (day:DateTime) =
    day.DayOfWeek = DayOfWeek.Saturday || day.DayOfWeek = DayOfWeek.Sunday

let WarningDays year =
    lastDays year
    |> Array.filter IsWeekend
