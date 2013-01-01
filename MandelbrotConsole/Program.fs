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
  let data = renderZebraMandelbrotSet (getFloatArg args 0 0.0) (getFloatArg args 1 0.0) (getFloatArg args 2 1.0)
  for x in 0..(Array2D.length1 data - 1) do
    for y in 0..(Array2D.length2 data - 1) do
      if data.[x, y] then printf "*" else printf " "
    printfn ""
  0