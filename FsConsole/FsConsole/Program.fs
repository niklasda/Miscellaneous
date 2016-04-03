
namespace FsConsole
    open System

    module Program =

        [<EntryPoint>]
        let Main  args = 
            
            File1.runMyTests

            File3.showFamily
            
            Console.ReadKey true |> ignore
            0
  