namespace Dailies

module Daily =

    let FirstSolution () =
        1

    let SumListTuplesEqualK (numbers : List<int>) (k : int) =
        let numbersMinusK = List.collect (fun x -> [abs(x - k)]) numbers

        let intersection = Set.intersect (Set.ofList numbers) (Set.ofList numbersMinusK)

        Operators.not intersection.IsEmpty