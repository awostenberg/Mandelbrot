module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

let getFloatArg (a : string []) i defaultVal =
  if (a.Length - 1) > i then
    a.[0] |> float
  else
    defaultVal

[<EntryPoint>]
let main args =
  renderZebraMandelbrotSet255x255 (getFloatArg args 0 0.0) (getFloatArg args 1 0.0) (getFloatArg args 2 1.0)
  0