namespace FsConsole

    module File1 =
        open System
    
        let names x = 
            match x with
            | 2.71 -> "e"
            | 3.14 -> "pi"
            | _ -> "unknown"

        let desc (d: obj) =
            match d with
            | :? int -> "int"
            | _ -> "?"

        let comp x y =
            match (x, y) with
            | (x, y) when x > y -> ">"
            | (x, y) when x < y -> "<"
            | _ -> "="

        type System.String with
            member x.IsCapitalized
                with get() =
                    Char.IsUpper(x.[0])
 
        let runMyTests = 
            let n = names 2.71
            let d = desc 2
            let c = comp 3 2

            printfn "%s" n
            printfn "%s" d
            printfn "%s" c

            let add x y = x + y
            let add1 = add 1
            printfn "%i" (add 4 5)
            printfn "%i" (add1 5)

            [   "Niklas"
                "Dahlman" ]
            |> Seq.iter (printfn "%s")

            let name = "Niklas"
            printfn "Caps? %b"
                name.IsCapitalized

