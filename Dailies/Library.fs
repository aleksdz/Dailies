namespace Dailies

module Daily =
    open System.Collections.Generic
    open System.Linq

    let FirstSolution () =
        1

    let SumListTuplesEqualK (numbers : List<int>) (k : int) =
        let hashset = HashSet numbers 
        hashset.Any(fun element -> hashset.Contains(k - element))

    let ListProducts (numbers : int list) =
        let rec products productList index =
            match productList with
            | [_] -> []
            | items -> List.Cons ([index * items.Head], (products items.Tail (index * items.Head)))

        let leftProducts = List.Cons (1, (List.collect (fun x -> x) (products numbers 1)))
        let rightProducts = List.rev (List.Cons (1, (List.collect (fun x -> x) (products (List.rev numbers) 1))))

        List.collect (fun (x, y) -> [x * y]) (List.zip leftProducts rightProducts)