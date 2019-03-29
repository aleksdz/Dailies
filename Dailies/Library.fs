namespace Dailies

module Daily =
    open System.Collections.Generic
    open System.Linq

    let FirstSolution () =
        1

    let SumListTuplesEqualK (numbers : List<int>) (k : int) =
        let hashset = HashSet numbers 
        hashset.Any(fun element -> hashset.Contains(k - element))
