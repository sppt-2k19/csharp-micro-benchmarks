using System;

namespace CSharp_Microbenches
{
    class Program
    {
        static void Main(string[] args)
        {
            var iterations = 5;
            var minTime = 250 * 1000000.0;
            var result = 0.0;
            
            result += Mark8("ScaleVector2D", Tests.ScaleVector2D, iterations, minTime);
            result += Mark8("ScaleVector3D", Tests.ScaleVector3D, iterations, minTime);
            result += Mark8("MultiplyVector2D", Tests.MultiplyVector2D, iterations, minTime);
            result += Mark8("MultiplyVector3D", Tests.MultiplyVector3D, iterations, minTime);
            result += Mark8("TranslateVector2D", Tests.TranslateVector2D, iterations, minTime);
            result += Mark8("TranslateVector3D", Tests.TranslateVector3D, iterations, minTime);
            result += Mark8("SubtractVector2D", Tests.SubtractVector2D, iterations, minTime);
            result += Mark8("SubtractVector3D", Tests.SubtractVector3D, iterations, minTime);
            result += Mark8("LengthVector2D", Tests.LengthVector2D, iterations, minTime);
            result += Mark8("LengthVector3D", Tests.LengthVector3D, iterations, minTime);
            result += Mark8("DotProductVector2D", Tests.Dotproduct2D, iterations, minTime);
            result += Mark8("DotProductVector3D", Tests.Dotproduct3D, iterations, minTime);
            
            Console.WriteLine("\n" + result);
        }
        
        public static double Mark8(string msg, Func<int, double> fun,
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
                            var sw = System.Diagnostics.Stopwatch.StartNew();
                            for (var i = 0; i < count; i++)
                            {
                                dummy += fun(i);
                            }
                            runningTime = sw.ElapsedTicks * 100.0f;
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
                    return dummy / totalCount;
                }
    }
}
