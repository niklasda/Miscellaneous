namespace FsConsole

    module File3 =

        open System

        type Person = {
            Name: string
            Age: int
            Gender: char
        }

        let family = [
            { Name = "Niklas"; Age = 42; Gender = 'M' }
            { Name = "Chris"; Age = 47; Gender = 'F' }
            { Name = "Alex"; Age = 9; Gender = 'M' }

        ]

        let parents = query {
            for p in family do
            where (p.Age > 18)
            sortByDescending p.Age
            distinct
            select p
            take 2
        }

        let showFamily = 
            for p in parents do
                printfn "%s" p.Name
