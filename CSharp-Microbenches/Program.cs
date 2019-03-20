using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CSharp_Microbenches
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterations = 5;
            var minTime = 250 * 1000000.0;
            var result = 0.0;

            var results = new List<Tuple<string, double, double, int, double>>
            {
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                
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
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime)
            };



            File.WriteAllText("results.csv",
                $"Test,Mean,Deviation,Count\n{string.Join('\n', results.Select(t => $"{t.Item1},{t.Item2:F3},{t.Item3:F3},{t.Item4}"))}");
                
            Console.WriteLine("\n" + results.Count);
        }
        
        
    }
}
