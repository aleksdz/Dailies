namespace Dailies

module Daily =
    open System.Collections.Generic
    open System.Linq

    let FirstSolution () =
        1

    let SumListTuplesEqualK (numbers : System.Collections.Generic.List<int>) (k : int) =
        let hashset = HashSet numbers 
        hashset.Any(fun element -> 
                        hashset.Contains(k - element) && 
                        if element = k/2 then 
                           numbers.Where(fun x -> x = element).Count () > 2 
                        else true)

    let ListProducts (numbers : int list) =
        let rec products productList temporaryValue =
            match productList with
            | [_] -> []
            | items -> List.Cons ([temporaryValue * items.Head], (products items.Tail (temporaryValue * items.Head)))

        let leftProducts = List.Cons (1, (List.collect (fun x -> x) (products numbers 1)))
        let rightProducts = List.rev (List.Cons (1, (List.collect (fun x -> x) (products (List.rev numbers) 1))))

        List.collect (fun (x, y) -> [x * y]) (List.zip leftProducts rightProducts)


    let LowestMissingNatural (numbers : int array) =
        for number, index in Seq.zip numbers [0 .. numbers.Length - 1] do
            if number < 0 then
                numbers.[index] <- Core.int.MaxValue
            elif number < numbers.Length then
                let x = numbers.[number]
                let i = min index number
                let j = max index number
                numbers.[i] <- min number x
                numbers.[j] <- max number x

        numbers
        |> Seq.fold
            (fun index number -> if number = (index + 1) then index + 1 else index)
            0
        |> ((+)1)