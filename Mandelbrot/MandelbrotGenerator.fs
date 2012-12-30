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

// Renders a B/W mandelbrot set onto a 255x255 2D Array of true/false values
let renderZebraMandelbrotSet255x255 cx cy zoom =
  let xStart, xStep, xEnd = -2.0 / zoom + cx, 0.0315 / zoom, 0.5 / zoom + cy
  let yStart, yStep, yEnd = -1.0 / zoom + cy, 0.05 / zoom, 1.0 / zoom + cy
  for y in yStart..yStep..yEnd do
    for x in xStart..xStep..xEnd do
      if isMandelbrot (new Complex(x, y)) then
        printf "*"
      else
        printf " "
    printfn ""