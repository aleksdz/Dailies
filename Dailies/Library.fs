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
        let mutable index = 0
        for element in numbers do
            if element < 0 then numbers.[index] <- FSharp.Core.int.MaxValue
            if element < numbers.Length && element > 0 then
                let temp = numbers.[element]
                if index < element then
                    numbers.[element] <- (max element temp)
                    numbers.[index] <- (min element temp)
                else numbers.[element] <- (min element temp)
                     numbers.[index] <- (max element temp)
                index <- index + 1
            else index <- index + 1

        let mutable value = 0
        for element in numbers do
            if element = (value + 1) then value <- value + 1

        value + 1