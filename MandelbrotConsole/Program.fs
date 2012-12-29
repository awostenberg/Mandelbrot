module MandelbrotConsole.Main
open System.Numerics
open MandelbrotGenerator

[<EntryPoint>]
let main args = 
  for y in (-1.0)..(0.05)..(1.0) do
    for x in (-2.0)..(0.0315)..(0.5) do
      if isMandelbrot (new Complex(x, y)) then
        printf "*"
      else
        printf " "
    printfn ""
  0