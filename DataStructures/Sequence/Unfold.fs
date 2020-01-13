module Unfold

// example below assume this function is defined
let IsMultipleOf (divider:int) (value:int) = value % divider = 0

// this is quite complex, and you can make do without it, so it's an extra credit item
let fizzBuzzUnfold() =
    1 // unfold requires 2 arguments: a function, and an initial state. As state is just a value, and is used as the initial iterator for the function
    |> Seq.unfold(fun i ->
        if i >= 100 then None // A "None" signals to Unfold that it should stop iterating
        else
            let item = 
                if  IsMultipleOf 3 i  && IsMultipleOf 5 i then "FizzBuss"
                else if IsMultipleOf 5 i then "Fizz"
                else if IsMultipleOf 3 i then "Buzz"
                else i.ToString() // remember, all elements of an array must be the same type
            Some(item, i+1))
    |> Seq.iter (fun s -> printfn "%s" s)

// Select every n:th day between two dates
open System

let IsWorkingDay (day: DateTime) = day.DayOfWeek <> DayOfWeek.Saturday && day.DayOfWeek <> DayOfWeek.Sunday

let DaysFollowing(start:DateTime) =
    Seq.initInfinite (fun i -> start.AddDays(float (i)))

let WorkingDaysFollowing start =
    start
    |> DaysFollowing
    |> Seq.filter IsWorkingDay

let NextWorkingDayAfter interval start =
    start
    |> WorkingDaysFollowing
    |> Seq.item interval

let ActionDays startDate endDate interval =
    Seq.unfold (fun date ->
        if date > endDate then None
        else
            let next = date |> NextWorkingDayAfter interval
            let dateString = date.ToString("dd-MM-yy dddd")
            Some(dateString, next)) startDate