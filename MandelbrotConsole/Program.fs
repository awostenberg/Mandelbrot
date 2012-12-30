module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

let getFloatArg (args : string []) i defaultVal =
  if i < args.Length then
    args.[i] |> float
  else
    defaultVal

[<EntryPoint>]
let main args =
  renderZebraMandelbrotSet (getFloatArg args 0 0.0) (getFloatArg args 1 0.0) (getFloatArg args 2 1.0)
  0