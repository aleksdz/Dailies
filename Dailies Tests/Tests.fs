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
        yield [| Collections.Generic.List([10;15;3;7]) :> obj; 17 :> obj; false   :> obj|]
        yield [| Collections.Generic.List([10;15;3;7]) :> obj; 16 :> obj; false   :> obj|]
        yield [| Collections.Generic.List([1;2;3;4])   :> obj; 3  :> obj; true    :> obj|]
        yield [| Collections.Generic.List([1;2;3;4])   :> obj; 1  :> obj; false   :> obj|]
        yield [| Collections.Generic.List([0;0;0;0])   :> obj; 0  :> obj; true    :> obj|]
        yield [| Collections.Generic.List([12312314;56754652;324356;85735246])    :> obj; 16   :> obj; false   :> obj|]
    }

[<Theory>]
[<MemberData("listTupleTestCases")>]
let ``Any List Tuple Sum Equals K`` (numbers : Collections.Generic.List<int>) (k : int) (expectedResult : bool) =
    let doesSumEqualK = Daily.SumListTuplesEqualK numbers k

    Assert.Equal(expectedResult, doesSumEqualK)

// Given a list of numbers, create a new list where every element is multiple of all elements bar itself.
let listProductsTestCases =
    seq {
        yield [| [1;2;3;4;5]    :> obj; [120;60;40;30;24]  :> obj|]
        yield [| [3;2;1]        :> obj; [2;3;6]            :> obj|]
        yield [| [0;1;2;3]      :> obj; [6;0;0;0]          :> obj|]
        yield [| [3;2;1;2]      :> obj; [4;6;12;6]         :> obj|]
    }

[<Theory>]
[<MemberData("listProductsTestCases")>]
let ``List products`` (numbers : int list) (expectedResult : int list) =
    let newList = Daily.ListProducts numbers

    Assert.True((expectedResult = newList))