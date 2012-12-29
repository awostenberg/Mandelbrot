module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

[<EntryPoint>]
let main args = 
  renderZebraMandelbrotSet255x255 () |> ignore
  0