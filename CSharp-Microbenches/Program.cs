﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using SestoftBenchmark;

namespace CSharp_Microbenches
{
    class Program
    {
        static void Main(string[] args)
        {
            
#if DEBUG 
            var mode = "debug";
#else
            var mode = "release";
#endif
            var iterations = 5;
            var minTime = 250 * 1000000.0;
            var result = 0.0;

            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            var d = Benchmark.Mark8("MapReduce Foreach", Tests.MapReduceForeach, iterations, minTime);
            var results = new List<(string label, double mean, double deviation, int count, double dummy)>
            {
                Benchmark.Mark8("MapReduce Foreach", Tests.MapReduceForeach, iterations, minTime),
                Benchmark.Mark8("MapReduce Foreach", Tests.MapReduceForeach, iterations, minTime),
                Benchmark.Mark8("MapReduce Foreach", Tests.MapReduceForeach, iterations, minTime),
                Benchmark.Mark8("MapReduce Foreach", Tests.MapReduceForeach, iterations, minTime),
                Benchmark.Mark8("MapReduce Foreach", Tests.MapReduceForeach, iterations, minTime),
                
                Benchmark.Mark8("MapReduce Linq", Tests.MapReduceLinq, iterations, minTime),
                Benchmark.Mark8("MapReduce Linq", Tests.MapReduceLinq, iterations, minTime),
                Benchmark.Mark8("MapReduce Linq", Tests.MapReduceLinq, iterations, minTime),
                Benchmark.Mark8("MapReduce Linq", Tests.MapReduceLinq, iterations, minTime),
                Benchmark.Mark8("MapReduce Linq", Tests.MapReduceLinq, iterations, minTime),
                
                Benchmark.Mark8("MapReduce Struct", Tests.MapReduceStruct, iterations, minTime),
                Benchmark.Mark8("MapReduce Struct", Tests.MapReduceStruct, iterations, minTime),
                Benchmark.Mark8("MapReduce Struct", Tests.MapReduceStruct, iterations, minTime),
                Benchmark.Mark8("MapReduce Struct", Tests.MapReduceStruct, iterations, minTime),
                Benchmark.Mark8("MapReduce Struct", Tests.MapReduceStruct, iterations, minTime),
                
                Benchmark.Mark8("Sestoft Multiply", Tests.Sestoft, iterations, minTime),
                Benchmark.Mark8("Sestoft Multiply", Tests.Sestoft, iterations, minTime),
                Benchmark.Mark8("Sestoft Multiply", Tests.Sestoft, iterations, minTime),
                Benchmark.Mark8("Sestoft Multiply", Tests.Sestoft, iterations, minTime),
                Benchmark.Mark8("Sestoft Multiply", Tests.Sestoft, iterations, minTime),
                
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                Benchmark.Mark8("Primes", Tests.Primes, iterations, minTime),
                
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                Benchmark.Mark8("RandomizeArray", Tests.RandomizeArray, iterations, minTime),
                
                Benchmark.Mark8("GameOfLife", Tests.IterateGameOfLifeTimes, iterations, minTime),
                Benchmark.Mark8("GameOfLife", Tests.IterateGameOfLifeTimes, iterations, minTime),
                Benchmark.Mark8("GameOfLife", Tests.IterateGameOfLifeTimes, iterations, minTime),
                Benchmark.Mark8("GameOfLife", Tests.IterateGameOfLifeTimes, iterations, minTime),
                Benchmark.Mark8("GameOfLife", Tests.IterateGameOfLifeTimes, iterations, minTime),
                
                Benchmark.Mark8("InvasionPercolation", Tests.RunInvasionPercolation, iterations, minTime),
                Benchmark.Mark8("InvasionPercolation", Tests.RunInvasionPercolation, iterations, minTime),
                Benchmark.Mark8("InvasionPercolation", Tests.RunInvasionPercolation, iterations, minTime),
                Benchmark.Mark8("InvasionPercolation", Tests.RunInvasionPercolation, iterations, minTime),
                Benchmark.Mark8("InvasionPercolation", Tests.RunInvasionPercolation, iterations, minTime),
                
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                Benchmark.Mark8("FibonacciRecursive", Tests.FibonacciRecursive, iterations, minTime),
                
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                Benchmark.Mark8("FibonacciIterative", Tests.FibonacciIterative, iterations, minTime),
                
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                Benchmark.Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime),
                
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                Benchmark.Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime),
                
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime),
                
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                Benchmark.Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime),
                
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                Benchmark.Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime),
                
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                Benchmark.Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime),
                
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                Benchmark.Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime),
                
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                Benchmark.Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime),
                
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                Benchmark.Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime),
                
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                Benchmark.Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime),
                
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                Benchmark.Mark8("DotProductVector2D", Tests.DotProduct2D, iterations, minTime),
                
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime),
                Benchmark.Mark8("DotProductVector3D", Tests.DotProduct3D, iterations, minTime)
            };



            File.WriteAllText($"results-{mode}.csv",
                $"Test,Mean,Deviation,Count\n{string.Join('\n', results.Select(t => $"{t.Item1},{t.Item2:F3},{t.Item3:F3},{t.Item4}"))}");
                
            Console.WriteLine("\n" + results.Count);
        }
        
        
    }
}
