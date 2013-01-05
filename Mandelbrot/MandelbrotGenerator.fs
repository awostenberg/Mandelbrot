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
let renderZebraMandelbrotSet width height cx cy powerZoom =
  let zoom = powerZoom ** 2.0
  let xStart, xStep, xEnd = -2.0 / zoom + cx, 4.0 / (width - 1 |> float) / zoom, 2.0 / zoom + cx
  let yStart, yStep, yEnd = -1.0 / zoom + cy, 4.0 / (height - 1 |> float) / zoom, 1.0 / zoom + cy
  let ary = Array2D.zeroCreate<bool> width height
  for x in xStart..xStep..xEnd do
    for y in yStart..yStep..yEnd do
      let rx, ry = (x - xStart) * (1.0 / xStep) |> int, (y - yStart) * (1.0 / yStep) |> int
      ary.[ry, rx] <- isMandelbrot (new Complex(x, y))
  ary