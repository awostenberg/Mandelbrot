module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

[<EntryPoint>]
let main args = 
  for x in (-2.0)..(0.1)..(2.0) do
    for y in (-2.0)..(0.1)..(2.0) do
      if isMandelbrot (new Complex(x, y)) then
        printf "*"
      else
        printf " "
    printfn ""
  0