module Tests

open System
open Xunit
open Dailies

[<Fact>]
let ``First Test`` () =
    Assert.Equal(1, Daily.FirstSolution ())

// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
let listTupleTestCases =
    seq {
        yield [|[10;15;3;7] :> obj; 17 :> obj; true    :> obj|]
        yield [|[10;15;3;7] :> obj; 16 :> obj; false   :> obj|]
        yield [|[1;2;3;4]   :> obj; 3  :> obj; true    :> obj|]
        yield [|[1;2;3;4]   :> obj; 1  :> obj; false   :> obj|]
        yield [|[0;0;0;0]   :> obj;  0 :> obj; true    :> obj|]
        yield [|[12312314;56754652;324356;85735246]    :> obj; 16   :> obj; false   :> obj|]
    }

[<Theory>]
[<MemberData("listTupleTestCases")>]
let ``Any List Tuple Sum Equals K`` (numbers : List<int>) (k : int) (expectedResult : bool) =
    let doesSumEqualK = Daily.SumListTuplesEqualK numbers k

    Assert.Equal(expectedResult, doesSumEqualK)