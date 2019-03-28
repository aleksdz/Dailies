module Tests

open System
open Xunit
open Dailies

[<Fact>]
let ``First Test`` () =
    Assert.Equal(1, Daily.FirstSolution ())

// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
[<Fact>]
let ``Any List Tuple Sum Equals K`` () =
    let numbers = [10;15;3;7]
    let k = 17

    let doesSumEqualK = Daily.SumListTuplesEqualK numbers k

    Assert.Equal(true, doesSumEqualK)