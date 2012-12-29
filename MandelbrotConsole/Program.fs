module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

[<EntryPoint>]
let main args =
  let zoom =
    if args.Length > 0 then
      args.[0] |> float
    else
      1.0
  renderZebraMandelbrotSet255x255 zoom |> ignore
  0