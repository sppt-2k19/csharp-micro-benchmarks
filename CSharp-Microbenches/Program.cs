using System;
using System.Collections.Generic;

namespace CSharp_Microbenches
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterations = 5;
            var minTime = 250 * 1000000.0;
            var result = 0.0;

            var s = nameof(Tests.FillArray);
            var results = new List<Tuple<string, double, double, int, double>>
            {
                Benchmark.Mark8("FillArray", Tests.FillArray, iterations, minTime),
                Benchmark.Mark8("FillJaggedArray", Tests.FillJaggedArray, iterations, minTime),
                
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                Benchmark.Mark8("DotProductVector2D", Tests.Dotproduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.Dotproduct3D, iterations, minTime)
            };


            Console.WriteLine("\n" + results.Count);
        }
        
        
    }
}
