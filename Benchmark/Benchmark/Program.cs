using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {
        [Benchmark]
        public void PointClassDistanceBench()
        {
            var pointOne = new PointClass();
            var pointTwo = new PointClass();
            pointOne.X = 5;
            pointOne.Y = 5;
            pointTwo.X = 8;
            pointTwo.Y = 8;
            PointClassDistance(pointOne, pointTwo);
        }
        public static float PointClassDistance(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void PointStructDistanceFloatBench()
        {
            var pointOne = new PointStruct();
            var pointTwo = new PointStruct();
            pointOne.X = 5;
            pointOne.Y = 5;
            pointTwo.X = 8;
            pointTwo.Y = 8;
            PointStructDistanceFloat(pointOne, pointTwo);
        }
        public static float PointStructDistanceFloat(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void PointStructDistanceDoubleBench()
        {
            var pointOne = new PointStruct();
            var pointTwo = new PointStruct();
            pointOne.X = 5;
            pointOne.Y = 5;
            pointTwo.X = 8;
            pointTwo.Y = 8;
            PointStructDistanceDouble(pointOne, pointTwo);
        }
        public static double PointStructDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        [Benchmark]
        public void PointDistanceShortBench()
        {
            var pointOne = new PointStruct();
            var pointTwo = new PointStruct();
            pointOne.X = 5;
            pointOne.Y = 5;
            pointTwo.X = 8;
            pointTwo.Y = 8;
            PointDistanceShort(pointOne, pointTwo);
        }
        public static float PointDistanceShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        public class PointClass
        {
            public int X;
            public int Y;
        }
        public struct PointStruct
        {
            public int X;
            public int Y;
        }
    }
}
