module Tests

open System
open Xunit
open Dailies

[<Fact>]
let ``First Test`` () =
    Assert.Equal(1, Daily.FirstSolution ())