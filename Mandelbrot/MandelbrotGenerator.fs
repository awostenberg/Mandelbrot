module MandelbrotGenerator
open System.Numerics

// Calculates wether or not the Mandelbrot set contains the complex point
let isMandelbrot c =
  let rec mandelbrotOf (oldComplex : Complex) (complex : Complex) maxI i =
    if i < maxI then
      mandelbrotOf oldComplex (complex * complex + oldComplex) maxI (i + 1)
    else
      complex
  abs ((mandelbrotOf c c 10 0).Magnitude) < 2.0

// Creates a 2D array full of true/false values -- true if the point is in the set, false if it is not
let renderMandelbrotSet () = Array2D.init 2 2 (fun x y -> isMandelbrot (new Complex(x |> float, y |> float)))