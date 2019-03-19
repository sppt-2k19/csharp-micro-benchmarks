using System;
using System.Collections.Generic;

namespace CSharp_Microbenches
{
    public static class Benchmark
    {
        public static Tuple<string, double, double, int, double> Mark8(string msg, Func<int, float> fun,
            int iterations, double minTime)
        {
            int count = 1, totalCount = 0;
            double dummy = 0.0, runningTime = 0.0, deltaTime = 0.0, deltaTimeSquared = 0.0;
            do
            {
                count *= 2;
                deltaTime = 0.0;
                deltaTimeSquared = 0.0;
                for (var j = 0; j < iterations; j++)
                {
                    var started = DateTime.UtcNow;
                    for (var i = 0; i < count; i++)
                    {
                        dummy += fun(i);
                    }
                    runningTime = DateTime.UtcNow.Subtract(started).TotalMilliseconds * 1000000.0f;
                    var time = runningTime / count;
                    deltaTime += time;
                    deltaTimeSquared += time * time;
                    totalCount += count;
                }
            } while (runningTime < minTime && count < int.MaxValue / 2);
        
            var mean = deltaTime / iterations;
            var standardDeviation = Math.Sqrt((deltaTimeSquared - mean * mean * iterations) / (iterations - 1));
            Console.WriteLine($"{msg};{mean};{standardDeviation};{count}"
                .Replace(',', '.')
                .Replace(';', ',')
            );
            //            Console.WriteLine($"{msg} done");
            return new Tuple<string, double, double, int, double>(msg, mean, standardDeviation, count, dummy);
        }
    }
}