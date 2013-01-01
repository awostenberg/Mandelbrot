module MandelbrotGenerator
open System.Numerics

// Calculates wether or not the Mandelbrot set contains the complex point
let isMandelbrot c =
  let rec mandelbrotOf (oldComplex : Complex) (complex : Complex) maxI i =
    if i < maxI then
      mandelbrotOf oldComplex (complex * complex + oldComplex) maxI (i + 1)
    else
      complex
  abs ((mandelbrotOf c c 50 0).Magnitude) < 2.0

// Renders a B/W mandelbrot set onto a 2D Array of true/false values
let renderZebraMandelbrotSet cx cy zoom =
  let xStart, xStep, xEnd = -2.0 / zoom + cx, 0.05 / zoom, 0.5 / zoom + cx
  let yStart, yStep, yEnd = -1.0 / zoom + cy, 0.0315 / zoom, 1.0 / zoom + cy
  let xw, yw = round xStart + xEnd / xStep |> int, round yStart + yEnd / yStep |> int
  let ary = Array2D.zeroCreate<bool> (abs ((xStart - xEnd) / xStep) + 1.0 |> int) (abs ((yStart - yEnd) / yStep) + 1.0 |> int)//(round xStart + xEnd / xStep |> int) (round yStart + yEnd / yStep |> int)
  for x in xStart..xStep..xEnd do
    for y in yStart..yStep..yEnd do
      let rx, ry = (x - xStart) * (1.0 / xStep) |> int, (y - yStart) * (1.0 / yStep) |> int
      //if not (rx = round rx) then printfn "WARNING: BAD X COMING UP"
      //if not (ry = round ry) then printfn "WARNING: BAD Y COMING UP"
      //printfn "(%f, %f) -> (%f, %f)" x y rx ry
      ary.[rx, ry] <- isMandelbrot (new Complex(x, y))
    //printfn ""
  ary