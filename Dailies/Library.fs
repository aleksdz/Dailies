namespace Dailies

module Daily =

    let FirstSolution () =
        1

    let SumListTuplesEqualK (numbers : List<int>) (k : int) =
        let tuplesSummed = List.collect (fun x -> List.collect (fun y -> [y + x]) numbers) numbers

        List.contains k tuplesSummed
