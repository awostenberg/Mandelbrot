module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

[<EntryPoint>]
let main args = 
  renderZebraMandelbrotSet () |> ignore
  0