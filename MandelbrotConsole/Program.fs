module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

[<EntryPoint>]
let main args = 
  renderMandelbrotSet () |> ignore
  0